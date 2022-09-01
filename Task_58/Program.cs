// Задача 58: Задайте две матрицы. 
// Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] CreateMatrixRndInt(int row, int col, int min, int max)
{
    int[,] matrix = new int[row, col];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],3},");
            else Console.Write($"{matrix[i, j],3} ");
        }
        Console.WriteLine("]");
    }
}


int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
{
    int rowResult = matrix1.GetLength(0);
    int colResult = matrix2.GetLength(1);
    int[,] result = new int[rowResult, colResult];

    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            result[i, j] = 0;
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                result[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }
    return result;
}

int[,] matrix11 = CreateMatrixRndInt(2, 2, 0, 9);
PrintMatrix(matrix11);
Console.WriteLine();
int[,] matrix22 = CreateMatrixRndInt(2, 2, 0, 9);
PrintMatrix(matrix22);
Console.WriteLine();
if (matrix11.GetLength(1) != matrix22.GetLength(0))
{
    Console.WriteLine("Такие матрицы нельзя перемножить, количество столбцов 1-й матрицы "
                     + "должно быть равно количеству строк 2-й матрицы");
}
else
{
    int[,] resultMatrix = MatrixMultiplication(matrix11, matrix22);
    Console.WriteLine("Результирующая матрица:");
    PrintMatrix(resultMatrix);
}