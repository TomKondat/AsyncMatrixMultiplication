
using System.Collections.Concurrent;
using System.Threading;

namespace Homework
{
    public class Matrix
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        public int[,] MyMatrix { get; private set; }

        public Matrix()
        {
            CreateMatrix();
        }

        public Matrix(int row, int col)
        {
            Row = row;
            Col = col;
            MyMatrix = new int[Row, Col];
        }

        public bool CheckMul(Matrix other)
        {
            if (Row == other.Col)
            {
                return true;
            }
            return false;
        }
        public void CreateMatrix()
        {
            Console.WriteLine("Choose matrix rows");
            Row = Validator.ValidateInput.ValidateNumber();
            Console.WriteLine("Choose matrix cols");
            Col = Validator.ValidateInput.ValidateNumber();
            MyMatrix = new int[Row, Col];
        }
        public void FillMatrix()
        {
            Random rnd = new Random();
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    MyMatrix[i, j] = rnd.Next(1, 10);
                }
            }
        }
        public void PrintMatrix()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    Console.Write(MyMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void MulMatrixSync(Matrix matrixA, Matrix matrixB)
        {
            for (int i = 0; i < matrixA.Row; i++)
            {
                for (int j = 0; j < matrixB.Col; j++)
                {
                    for (int k = 0; k < matrixA.Col; k++)
                    {
                        MyMatrix[i, j] += matrixA.MyMatrix[i, k] * matrixB.MyMatrix[k, j];
                    }
                }
            }
        }

        public async Task MulMatrixAsync(Matrix matrixA, Matrix matrixB, int maxTasks)
        {
            ConcurrentQueue<int> rowQueue = new ConcurrentQueue<int>();

            for (int i = 0; i < matrixA.Row; i++)
            {
                rowQueue.Enqueue(i);
            }

            foreach (var row in rowQueue)
            {
                await ProcessRowAsync(row, matrixA, matrixB, maxTasks);
            }

            Console.WriteLine("Finished async matrix multiplication.");
        }
        private async Task ProcessRowAsync(int row, Matrix matrixA, Matrix matrixB, int maxTasks)
        {
            //var tasks = new List<Task>();

            for (int i = 0; i < maxTasks; i++)
            {
                await Task.Run(async () =>
                {
                    for (int j = 0; j < matrixB.Col; j++)
                    {
                        var cellValue = 0;
                        for (int k = 0; k < matrixA.Col; k++)
                        {
                            cellValue += matrixA.MyMatrix[row, k] * matrixB.MyMatrix[k, j];
                        }
                        MyMatrix[row, j] = cellValue;
                        //await Task.Delay(1);
                    }
                });
            }

            //await Task.WhenAll(tasks);
        }
        //private async Task MultiplyRowAsync(int row, Matrix matrixA, Matrix matrixB)
        //{
        //    for (int j = 0; j < matrixB.Col; j++)
        //    {
        //        var cellValue = 0;
        //        for (int k = 0; k < matrixA.Col; k++)
        //        {
        //            cellValue += matrixA.MyMatrix[row, k] * matrixB.MyMatrix[k, j];
        //        }
        //        MyMatrix[row, j] = cellValue;
        //        await Task.Delay(1);
        //    }
        //}
    }
}
