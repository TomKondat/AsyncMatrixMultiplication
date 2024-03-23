using System.Collections.Concurrent;
using Homework.Models;

namespace Homework
{
    public class MatrixMultiplication
    {
        public Matrix MatrixA { get; set; }
        public Matrix MatrixB { get; set; }

        public MatrixMultiplication(Matrix a , Matrix b)
        {
            MatrixA = a;
            MatrixB = b;
        }
        public Matrix MulMatrixSync()
        {
            var MatrixC = new Matrix(MatrixA.Row, MatrixB.Col);
            for (int i = 0; i < MatrixA.Row; i++)
            {
                for (int j = 0; j < MatrixB.Col; j++)
                {
                    for (int k = 0; k < MatrixA.Col; k++)
                    {
                        MatrixC.MyMatrix[i, j] += MatrixA.MyMatrix[i, k] * MatrixB.MyMatrix[k, j];
                    }
                }
            }
            return MatrixC;
        }
        public async Task<Matrix> MulMatrixAsync( int maxTasks)
        {
            var MatrixC = new Matrix(MatrixA.Row, MatrixB.Col);

            ConcurrentQueue<int> rowQueue = new ConcurrentQueue<int>();

            for (int i = 0; i < MatrixA.Row; i++)
            {
                rowQueue.Enqueue(i);
            }

            var tasks = new List<Task>();

            for (int i = 0; i < maxTasks; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    await CalculateRow(MatrixC, rowQueue);
                }));
            }
            await Task.WhenAll(tasks);

            Console.WriteLine("Finished Working");

            return MatrixC;
        }
        private async Task CalculateRow(Matrix MatrixC, ConcurrentQueue<int> rowQueue)
        {
            while (rowQueue.TryDequeue(out int rowIndex))
            {
                for (int j = 0; j < MatrixB.Col; j++)
                {
                    var cellValue = 0;
                    for (int k = 0; k < MatrixA.Col; k++)
                    {
                        cellValue += MatrixA.MyMatrix[rowIndex, k] * MatrixB.MyMatrix[k, j];
                    }
                    MatrixC.MyMatrix[rowIndex, j] = cellValue;
                }
                await Task.Delay(1);
            }
        }
    }
}
