using System;
using System.Collections.Generic;
using System.Text;

namespace RTC
{
    /// <summary>
    /// This class does something.
    /// </summary>
    public class Matrix
    {
        double[,] matrix;
        int rows;
        int columns;

        public Matrix(int rows, int columns)
        {
            matrix = new double[rows, columns];
            this.rows = rows;
            this.columns = columns;
        }
        public Matrix()
        {
            //Default 4 x 4 matrix
            matrix = new double[4, 4];
            rows = 4;
            columns = 4;
        }
        public static Matrix GetIdentity()
        {
            Matrix temp = new Matrix();
            temp[0, 0] = 1;
            temp[0, 1] = 0;
            temp[0, 2] = 0;
            temp[0, 3] = 0;
            temp[1, 0] = 0;
            temp[1, 1] = 1;
            temp[1, 2] = 0;
            temp[1, 3] = 0;
            temp[2, 0] = 0;
            temp[2, 1] = 0;
            temp[2, 2] = 1;
            temp[2, 3] = 0;
            temp[3, 0] = 0;
            temp[3, 1] = 0;
            temp[3, 2] = 0;
            temp[3, 3] = 1;
            return temp;

        }
        public Matrix Identity()
        {
            this[0, 0] = 1;
            this[0, 1] = 0;
            this[0, 2] = 0;
            this[0, 3] = 0;
            this[1, 0] = 0;
            this[1, 1] = 1;
            this[1, 2] = 0;
            this[1, 3] = 0;
            this[2, 0] = 0;
            this[2, 1] = 0;
            this[2, 2] = 1;
            this[2, 3] = 0;
            this[3, 0] = 0;
            this[3, 1] = 0;
            this[3, 2] = 0;
            this[3, 3] = 1;
            return this;
        }
        public double this[int r, int c]
        {
            //bracket overloading
            get { return matrix[r, c]; }
            set { matrix[r, c] = value; }
        }
        public static bool Equal(double inp_a, double inp_b)
        {
            double Epsilon = 0.00001;
            if (Math.Abs(inp_a - inp_b) < Epsilon)
            {
                return true;
            }
            else { return false; }
        }
        public static bool operator ==(Matrix A, Matrix B)
        {
            if (A.rows != B.rows || A.columns != B.columns) { return false; }

            for (int row = 0; row < A.rows; row++)
            {
                for (int column = 0; column < A.columns; column++)
                {
                    if (!Equal(A[row, column], B[row, column]))
                    { return false; }
                }
            }
            return true;
        }
        public static bool operator !=(Matrix A, Matrix B)
        {
            return !(A == B);
        }
        private static double[] MatrixMulti(Matrix input_matrix, double[] input_array)
        {
            //helper method for matrix multiplying with tuple, point and vector
            //recieves matrix and tuple, point, vector from three * operator methods
            //and returns a float array. This to avoid multiply return types from the * operator
            double[] output_array = new double[4];
            for (int r = 0; r != 4; r++)
            {
                for (int i = 0; i != 4; i++)
                {
                    output_array[r] += input_matrix[r, i] * input_array[i];
                }
            }
            return output_array;
        }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix return_matrix = new Matrix(4, 4);
            for (int row = 0; row != 4; row++)
            {
                for (int column = 0; column != 4; column++)
                {
                    return_matrix[row, column] =
                                                A[row, 0] * B[0, column] +
                                                A[row, 1] * B[1, column] +
                                                A[row, 2] * B[2, column] +
                                                A[row, 3] * B[3, column];
                }
            }
            return return_matrix;
        }
        public static Vector operator *(Matrix input_matrix, Vector input_vector)
        {
            //CsMatrix temp_matrix = new CsMatrix(4, 1);//temp matrix to store valuesi
            //måske ikke nødvendigt, da translations ikke virker på vectorer.
            double[] argument_array = new double[4];
            argument_array[0] = input_vector.x;
            argument_array[1] = input_vector.y;
            argument_array[2] = input_vector.z;
            argument_array[3] = input_vector.w;
            double[] recieved_values = MatrixMulti(input_matrix, argument_array);
            Vector out_vector = new Vector();
            out_vector.x = recieved_values[0];
            out_vector.y = recieved_values[1];
            out_vector.z = recieved_values[2];
            out_vector.w = recieved_values[3];
            return out_vector;
        }
        public static Point operator *(Matrix input_matrix, Point input_point)
        {
            //CsMatrix temp_matrix = new CsMatrix(4, 1);//temp matrix to store valuesi
            double[] argument_array = new double[4];
            argument_array[0] = input_point.x;
            argument_array[1] = input_point.y;
            argument_array[2] = input_point.z;
            argument_array[3] = input_point.w;
            double[] recieved_values = MatrixMulti(input_matrix, argument_array);
            Point output_point = new Point(0, 0, 0);
            output_point.x = recieved_values[0];
            output_point.y = recieved_values[1];
            output_point.z = recieved_values[2];
            output_point.w = recieved_values[3];
            return output_point;
        }
        public override string ToString()
        {
            string out_string = "";
            for (int row = 0; row < rows; row++)
            {
                out_string += "|";
                for (int column = 0; column < columns; column++)
                {
                    out_string += this[row, column].ToString() + ", ";

                }
                out_string += "|\n";

            }
            return out_string;
        }
        public Matrix Transpose()
        {
            //this method is implemented as static to be used testing the identity matrix.
            Matrix temp = new Matrix();
            //copy element from this to
            for (int r = 0; r < 4; r++)
            {
                for (int i = 0; i < 4; i++)
                {
                    temp[r, i] = this[r, i];
                }
            }
            for (int row = 0; row != 4; row++)
            {
                for (int column = 0; column != 4; column++)
                {
                    this[row, column] = temp[column, row];
                }
            }
            return this;
        }
        public static double Determinant(Matrix input_matrix)
        {
            double determinant = 0;
            if (input_matrix.rows == 2 && input_matrix.columns == 2)//if 3 x 3 matrix
            {
                double a = input_matrix[0, 0];
                double b = input_matrix[0, 1];
                double c = input_matrix[1, 0];
                double d = input_matrix[1, 1];
                determinant = (a * d) - (b * c);
            }
            else
            {
                for (int c = 0; c < input_matrix.rows; c++)
                {
                    float cofactor = Cofactor(input_matrix, 0, c);
                    float temp = (float)input_matrix[0, c];
                    //determinant += Cofactor(input_matrix, 0, c) * input_matrix.grid[0, c];
                    determinant += cofactor * temp;
                }
            }
            return determinant;
        }
        public static Matrix MakeSubMatrix(Matrix input_matrix, int row_to_delete, int column_to_delete)
        {
            // removes the indicated row and column thus makes a submatrix of the input_matrix
            int row_offset_in_output_matrix = 0;
            int column_offset_in_output_matrix = 0;
            Matrix output_matrix = new Matrix(input_matrix.rows - 1, input_matrix.columns - 1);
            for (int r = 0; r < input_matrix.rows; r++)
            {
                if (r == row_to_delete) { continue; }
                for (int c = 0; c < input_matrix.columns; c++)
                {
                    if (c == column_to_delete) { continue; }
                    output_matrix[row_offset_in_output_matrix,
                                 column_offset_in_output_matrix] = input_matrix[r, c];
                    column_offset_in_output_matrix += 1;
                    if (column_offset_in_output_matrix == output_matrix.columns)
                    {
                        row_offset_in_output_matrix += 1;
                        column_offset_in_output_matrix = 0;
                    }
                }
            }
            return output_matrix;
        }
        public static double Minor(Matrix input_matrix, int row_to_delete, int column_to_delete)
        {
            Matrix submatrix = MakeSubMatrix(input_matrix, row_to_delete, column_to_delete);
            double cal_determinant = Determinant(submatrix);
            return cal_determinant;
        }
        public static int Cofactor(Matrix input_matrix, int row_to_delelte, int column_to_delete)
        {
            // video about Cofactors https://www.youtube.com/watch?v=KMKd993vG9Q
            double minor = Minor(input_matrix, row_to_delelte, column_to_delete);
            int sign;
            if ((row_to_delelte + column_to_delete) % 2 != 0)
            { sign = -1; }
            else
            { sign = 1; }
            return sign * (int)minor;
        }
        public static bool IsInvertable(Matrix input_matrix)
        {
            double return_value = Determinant(input_matrix);
            if (return_value == 0) { return false; }
            else { return true; }
        }
        public static Matrix Inverse(Matrix input_matrix)
        {

            double determinant = Determinant(input_matrix);
            bool assert_value;
            if (determinant == 0) { assert_value = false; }
            else { assert_value = true; }
            //System.Diagnostics.Debug.Assert(assert_value, "NOT POSSIBLE TO INVERT MATRIX!");
            Matrix return_matrix = new Matrix(4, 4);
            for (int row = 0; row != input_matrix.rows; row++)
            {
                for (int col = 0; col != input_matrix.columns; col++)
                {
                    var c = Cofactor(input_matrix, row, col);
                    return_matrix[col, row] = c / Determinant(input_matrix);
                }

            }
            return return_matrix;
        }
        public Matrix Translation(double x, double y, double z)
        {
            matrix = GetTranslation(x, y, z).matrix;
            return this;
        }
        public static Matrix GetTranslation(double x, double y, double z)
        {
            Matrix temp = new Matrix();
            temp[0, 0] = 1;
            temp[0, 3] = x;
            temp[1, 1] = 1;
            temp[1, 3] = y;
            temp[2, 2] = 1;
            temp[2, 3] = z;
            temp[3, 3] = 1;
            return temp;
        }
        public Matrix Scaling(double x, double y, double z)
        {
            matrix = GetScaling(x, y, z).matrix;
            return this;
        }
        public static Matrix GetScaling(double x, double y, double z)
        {
            Matrix temp = new Matrix();
            temp[0, 0] = x;
            temp[1, 1] = y;
            temp[2, 2] = z;
            temp[3, 3] = 1;
            return temp;
        }
        public Matrix Rotate_x(double r)
        {
            matrix = GetRotateX(r).matrix;
            return this;
        }
        public static Matrix GetRotateX(double r)
        {
            Matrix temp = new Matrix();
            temp[0, 0] = 1;
            temp[1, 1] = Math.Cos(r);
            temp[1, 2] = -1 * Math.Sin(r);
            temp[2, 1] = Math.Sin(r);
            temp[2, 2] = Math.Cos(r);
            temp[3, 3] = 1;
            return temp;
        }
        public Matrix Rotate_y(double r)
        {
            matrix = GetRotateY(r).matrix;
            return this;
        }
        public static Matrix GetRotateY(double r)
        {
            Matrix temp = new Matrix();
            temp[0, 0] = Math.Cos(r);
            temp[0, 2] = Math.Sin(r);
            temp[2, 0] = -1 * Math.Sin(r);
            temp[2, 2] = Math.Cos(r);
            temp[1, 1] = 1;
            temp[3, 3] = 1;
            return temp;
        }
        public Matrix Rotate_z(double r)
        {
            matrix = GetRotateZ(r).matrix;
            return this;
        }
        public static Matrix GetRotateZ(double r)
        {
            Matrix temp = new Matrix();
            temp[0, 0] = Math.Cos(r);
            temp[0, 1] = Math.Sin(r) * -1;
            temp[1, 0] = Math.Sin(r);
            temp[1, 1] = Math.Cos(r);
            temp[2, 2] = 1;
            temp[3, 3] = 1;
            return temp;
        }
        public Matrix Shearing(double xy, double xz, double yx, double yz, double zx, double zy)
        {
            matrix = GetShearing(xy, xz, yx, yz, zx, zy).matrix;
            return this;
        }
        public static Matrix GetShearing(double xy, double xz, double yx, double yz, double zx, double zy)
        {
            Matrix temp = new Matrix();
            temp[0, 0] = 1;
            temp[0, 1] = xy;
            temp[0, 2] = xz;
            temp[1, 0] = yx;
            temp[1, 1] = 1;
            temp[1, 2] = yz;
            temp[2, 0] = zx;
            temp[2, 1] = zy;
            temp[2, 2] = 1;
            temp[3, 3] = 1;
            return temp;

        }
    }
}

namespace RTC
{
    using RTC;
    public static class CsIdentityMatrix
    {
        public static Matrix IdentityMatrix()
        {
            Matrix identity_matrix = new Matrix(4, 4);
            identity_matrix[0, 0] = 1;
            identity_matrix[1, 1] = 1;
            identity_matrix[2, 2] = 1;
            identity_matrix[3, 3] = 1;
            return identity_matrix;
        }
    }
}
