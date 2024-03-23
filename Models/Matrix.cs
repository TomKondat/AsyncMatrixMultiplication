namespace Homework.Models
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
        public bool CheckMul(Matrix other)
        {
            if (Row == other.Col)
            {
                return true;
            }
            return false;
        }

    }
}
