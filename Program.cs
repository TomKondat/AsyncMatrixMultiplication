
using Homework.Models;

namespace Homework
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var matrixA = new Matrix();
            var matrixB = new Matrix();

            if (!matrixA.CheckMul(matrixB))
            {
                Console.WriteLine("Cant multiply matrix.");
                return;
            }

            matrixA.FillMatrix();
            //matrixA.PrintMatrix();

            matrixB.FillMatrix();
            //matrixB.PrintMatrix();

            var matrixMultiplication = new MatrixMultiplication(matrixA, matrixB);
            var stopwatch1 = System.Diagnostics.Stopwatch.StartNew();
            var matrixC = matrixMultiplication.MulMatrixSync();
            stopwatch1.Stop();
            Console.WriteLine($"Time took for sync funtion is : {stopwatch1}");
            //matrixC.PrintMatrix();

            Console.WriteLine("How many Tasks you want for async function?");
            var maxTasks = Validator.ValidateInput.ValidateTask();
            var stopwatch2 = System.Diagnostics.Stopwatch.StartNew();
            var matrixCAsync = await matrixMultiplication.MulMatrixAsync(maxTasks);
            stopwatch2.Stop();
            Console.WriteLine($"Time took for async funtion is : {stopwatch2}");
            //matrixCAsync.PrintMatrix();

        }
    }
}
