
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

            var matrixC = new Matrix(matrixA.Row, matrixB.Col);
            var matrixD = new Matrix(matrixA.Row, matrixB.Col);

            var stopwatch1 = System.Diagnostics.Stopwatch.StartNew();
            matrixC.MulMatrixSync(matrixA, matrixB);
            stopwatch1.Stop();
            Console.WriteLine($"Time took for sync funtion is : {stopwatch1}");
            //matrixC.PrintMatrix();

            Console.WriteLine("How many Tasks you want for async function?");
            var maxTasks = Validator.ValidateInput.ValidateTask();
            var stopwatch2 = System.Diagnostics.Stopwatch.StartNew();
            await matrixD.MulMatrixAsync(matrixA, matrixB, maxTasks);
            stopwatch2.Stop();
            Console.WriteLine($"Time took for async funtion is : {stopwatch2}");
            //matrixD.PrintMatrix();
        }
    }
}
