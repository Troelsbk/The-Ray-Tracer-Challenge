﻿using static RTC.CsIdentityMatrix;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTC
{
    public class MatrixTest
    {
        [Fact]
        public void matrixTest()
        {
            Matrix Matrix_A = new Matrix(4, 4);
            Matrix_A[0, 0] = 1;
            Matrix_A[0, 1] = 2;
            Matrix_A[0, 2] = 3;
            Matrix_A[0, 3] = 4;
            Matrix_A[1, 0] = 5;
            Matrix_A[1, 1] = 6;
            Matrix_A[1, 2] = 7;
            Matrix_A[1, 3] = 8;
            Matrix_A[2, 0] = 9;
            Matrix_A[2, 1] = 8;
            Matrix_A[2, 2] = 7;
            Matrix_A[2, 3] = 6;
            Matrix_A[3, 0] = 5;
            Matrix_A[3, 1] = 4;
            Matrix_A[3, 2] = 3;
            Matrix_A[3, 3] = 2;
            Matrix Matrix_B = new Matrix(4, 4);
            Matrix_B[0, 0] = 1;
            Matrix_B[0, 1] = 2;
            Matrix_B[0, 2] = 3;
            Matrix_B[0, 3] = 4;
            Matrix_B[1, 0] = 5;
            Matrix_B[1, 1] = 6;
            Matrix_B[1, 2] = 7;
            Matrix_B[1, 3] = 8;
            Matrix_B[2, 0] = 9;
            Matrix_B[2, 1] = 8;
            Matrix_B[2, 2] = 7;
            Matrix_B[2, 3] = 6;
            Matrix_B[3, 0] = 5;
            Matrix_B[3, 1] = 4;
            Matrix_B[3, 2] = 3;
            Matrix_B[3, 3] = 2;
            Matrix Matrix_C = new Matrix(100, 5);
            Assert.True(Matrix_A == Matrix_B);
            Assert.False(Matrix_A != Matrix_B);
            Matrix_B[3, 3] = 2.00001d;
            Assert.True(Matrix_A != Matrix_B);
            Assert.False(Matrix_A == Matrix_B);
            Assert.False(Matrix_C == Matrix_A);
            //MULTIPLICATION TEST
            Matrix Matrix_D = new Matrix(4, 4);
            Matrix Matrix_E = new Matrix(4, 4);
            Matrix Matrix_F = new Matrix(4, 4);
            Matrix_D[0, 0] = 1;
            Matrix_D[0, 1] = 2;
            Matrix_D[0, 2] = 3;
            Matrix_D[0, 3] = 4;
            Matrix_D[1, 0] = 5;
            Matrix_D[1, 1] = 6;
            Matrix_D[1, 2] = 7;
            Matrix_D[1, 3] = 8;
            Matrix_D[2, 0] = 9;
            Matrix_D[2, 1] = 8;
            Matrix_D[2, 2] = 7;
            Matrix_D[2, 3] = 6;
            Matrix_D[3, 0] = 5;
            Matrix_D[3, 1] = 4;
            Matrix_D[3, 2] = 3;
            Matrix_D[3, 3] = 2;

            Matrix_E[0, 0] = -2;
            Matrix_E[0, 1] = 1;
            Matrix_E[0, 2] = 2;
            Matrix_E[0, 3] = 3;
            Matrix_E[1, 0] = 3;
            Matrix_E[1, 1] = 2;
            Matrix_E[1, 2] = 1;
            Matrix_E[1, 3] = -1;
            Matrix_E[2, 0] = 4;
            Matrix_E[2, 1] = 3;
            Matrix_E[2, 2] = 6;
            Matrix_E[2, 3] = 5;
            Matrix_E[3, 0] = 1;
            Matrix_E[3, 1] = 2;
            Matrix_E[3, 2] = 7;
            Matrix_E[3, 3] = 8;

            Matrix_F[0, 0] = 20;
            Matrix_F[0, 1] = 22;
            Matrix_F[0, 2] = 50;
            Matrix_F[0, 3] = 48;
            Matrix_F[1, 0] = 44;
            Matrix_F[1, 1] = 54;
            Matrix_F[1, 2] = 114;
            Matrix_F[1, 3] = 108;
            Matrix_F[2, 0] = 40;
            Matrix_F[2, 1] = 58;
            Matrix_F[2, 2] = 110;
            Matrix_F[2, 3] = 102;
            Matrix_F[3, 0] = 16;
            Matrix_F[3, 1] = 26;
            Matrix_F[3, 2] = 46;
            Matrix_F[3, 3] = 42;
            Assert.True(Matrix_F == (Matrix_D * Matrix_E));

            Matrix Matrix_G = new Matrix(4, 4);
            Matrix_G[0, 0] = 1;
            Matrix_G[0, 1] = 2;
            Matrix_G[0, 2] = 3;
            Matrix_G[0, 3] = 4;
            Matrix_G[1, 0] = 2;
            Matrix_G[1, 1] = 4;
            Matrix_G[1, 2] = 4;
            Matrix_G[1, 3] = 2;
            Matrix_G[2, 0] = 8;
            Matrix_G[2, 1] = 6;
            Matrix_G[2, 2] = 4;
            Matrix_G[2, 3] = 1;
            Matrix_G[3, 0] = 0;
            Matrix_G[3, 1] = 0;
            Matrix_G[3, 2] = 0;
            Matrix_G[3, 3] = 1;
            Point input_tuple = new Point(1, 2, 3);
            Point expected_tuple = new Point(18, 24, 33);
            Point calculated_tuple = Matrix_G * input_tuple;
            Assert.True(expected_tuple == calculated_tuple);
            //identity matrix multiplied by matrix
            Matrix identity_multiply_result_matrix = Matrix_G * CsIdentityMatrix.IdentityMatrix();
            bool identity_compare_result_matrix = Matrix_G == identity_multiply_result_matrix;
            Assert.True(identity_compare_result_matrix);

            //Transposing Matrices
            Matrix before_transposing = new Matrix(4, 4);
            before_transposing[0, 0] = 0;
            before_transposing[0, 1] = 9;
            before_transposing[0, 2] = 3;
            before_transposing[0, 3] = 0;
            before_transposing[1, 0] = 9;
            before_transposing[1, 1] = 8;
            before_transposing[1, 2] = 0;
            before_transposing[1, 3] = 8;
            before_transposing[2, 0] = 1;
            before_transposing[2, 1] = 8;
            before_transposing[2, 2] = 5;
            before_transposing[2, 3] = 3;
            before_transposing[3, 0] = 0;
            before_transposing[3, 1] = 0;
            before_transposing[3, 2] = 5;
            before_transposing[3, 3] = 8;
            Matrix transpose_expected = new Matrix(4, 4);
            transpose_expected[0, 0] = 0;
            transpose_expected[0, 1] = 9;
            transpose_expected[0, 2] = 1;
            transpose_expected[0, 3] = 0;
            transpose_expected[1, 0] = 9;
            transpose_expected[1, 1] = 8;
            transpose_expected[1, 2] = 8;
            transpose_expected[1, 3] = 0;
            transpose_expected[2, 0] = 3;
            transpose_expected[2, 1] = 0;
            transpose_expected[2, 2] = 5;
            transpose_expected[2, 3] = 5;
            transpose_expected[3, 0] = 0;
            transpose_expected[3, 1] = 8;
            transpose_expected[3, 2] = 3;
            transpose_expected[3, 3] = 8;
            before_transposing.Transpose();
            Assert.True(before_transposing == transpose_expected);
            //to to implement transpose of identity matrix test
            Matrix IdentityMatrix = new Matrix();
            IdentityMatrix.Identity();
            Matrix i = new Matrix();
            i[0, 0] = 1;
            i[0, 1] = 0;
            i[0, 2] = 0;
            i[0, 3] = 0;
            i[1, 0] = 0;
            i[1, 1] = 1;
            i[1, 2] = 0;
            i[1, 3] = 0;
            i[2, 0] = 0;
            i[2, 1] = 0;
            i[2, 2] = 1;
            i[2, 3] = 0;
            i[3, 0] = 0;
            i[3, 1] = 0;
            i[3, 2] = 0;
            i[3, 3] = 1;
            Assert.True(IdentityMatrix == i);

            //IMPLEMENTING THE INVERTING ALGORITHM.
            //testing determinant
            Matrix determinant_matrix_input = new Matrix(2, 2);
            determinant_matrix_input[0, 0] = 1;
            determinant_matrix_input[0, 1] = 5;
            determinant_matrix_input[1, 0] = -3;
            determinant_matrix_input[1, 1] = 2;
            Assert.Equal(17, Matrix.Determinant(determinant_matrix_input));

            //Submatrix test
            //test one
            Matrix submatrix_input = new Matrix(3, 3);
            submatrix_input[0, 0] = 1;
            submatrix_input[0, 1] = 5;
            submatrix_input[0, 2] = 0;
            submatrix_input[1, 0] = -3;
            submatrix_input[1, 1] = 2;
            submatrix_input[1, 2] = 7;
            submatrix_input[2, 0] = 0;
            submatrix_input[2, 1] = 6;
            submatrix_input[2, 2] = -3;
            Matrix submatrix_output = Matrix.MakeSubMatrix(submatrix_input, 0, 2);
            Matrix expected_submatrix = new Matrix(2, 2);
            expected_submatrix[0, 0] = -3;
            expected_submatrix[0, 1] = 2;
            expected_submatrix[1, 0] = 0;
            expected_submatrix[1, 1] = 6;
            Assert.True(expected_submatrix == submatrix_output);
            //try another compination
            Matrix submatrix_output_copy = Matrix.MakeSubMatrix(submatrix_input, 2, 2);
            expected_submatrix[0, 0] = 1;
            expected_submatrix[0, 1] = 5;
            expected_submatrix[1, 0] = -3;
            expected_submatrix[1, 1] = 2;
            Assert.True(expected_submatrix == submatrix_output_copy);
            //Manipulating Minors
            Matrix minors_matrix_input = new Matrix(3, 3);
            minors_matrix_input[0, 0] = 3;
            minors_matrix_input[0, 1] = 5;
            minors_matrix_input[0, 2] = 0;
            minors_matrix_input[1, 0] = 2;
            minors_matrix_input[1, 1] = -1;
            minors_matrix_input[1, 2] = -7;
            minors_matrix_input[2, 0] = 6;
            minors_matrix_input[2, 1] = -1;
            minors_matrix_input[2, 2] = 5;
            Matrix minors_matrinx_output = Matrix.MakeSubMatrix(minors_matrix_input, 1, 0);
            int expected_determinant = 25;
            int calculated_determinant = (int)Matrix.Determinant(minors_matrinx_output);
            Assert.Equal(expected_determinant, calculated_determinant);
            Assert.Equal(expected_determinant, Matrix.Minor(minors_matrix_input, 1, 0));

            //Computing Cofactors 
            Matrix cofactor_input = new Matrix(3, 3);
            cofactor_input[0, 0] = 3;
            cofactor_input[0, 1] = 5;
            cofactor_input[0, 2] = 0;
            cofactor_input[1, 0] = 2;
            cofactor_input[1, 1] = -1;
            cofactor_input[1, 2] = -7;
            cofactor_input[2, 0] = 6;
            cofactor_input[2, 1] = -1;
            cofactor_input[2, 2] = 5;
            //first test
            int expected_minor = -12;
            int calculated_minor = (int)Matrix.Minor(cofactor_input, 0, 0);
            Assert.Equal(expected_minor, calculated_minor);
            Assert.Equal(expected_minor, Matrix.Cofactor(cofactor_input, 0, 0));
            //second test
            expected_minor = 25;
            calculated_minor = (int)Matrix.Minor(cofactor_input, 1, 0);
            Assert.Equal(expected_minor, calculated_minor);
            int expected_cofactor = -25;
            int calculated_cofactor = Matrix.Cofactor(cofactor_input, 1, 0);
            Assert.Equal(expected_cofactor, calculated_cofactor);
            //Determining Determinants of Larger Matrices
            Matrix cofactor_input_0 = new Matrix(3, 3);
            cofactor_input_0[0, 0] = 1;
            cofactor_input_0[0, 1] = 2;
            cofactor_input_0[0, 2] = 6;
            cofactor_input_0[1, 0] = -5;
            cofactor_input_0[1, 1] = 8;
            cofactor_input_0[1, 2] = -4;
            cofactor_input_0[2, 0] = 2;
            cofactor_input_0[2, 1] = 6;
            cofactor_input_0[2, 2] = 4;
            Assert.Equal(56, Matrix.Cofactor(cofactor_input_0, 0, 0));
            Assert.Equal(12, Matrix.Cofactor(cofactor_input_0, 0, 1));
            Assert.Equal(-46, Matrix.Cofactor(cofactor_input_0, 0, 2));
            //Assert.Equal(-196, Matrix.Determinant(cofactor_input_0));//surposed to fail in first run?
            //Second test
            Matrix cofactor_input_2 = new Matrix(4, 4);
            cofactor_input_2[0, 0] = -2;
            cofactor_input_2[0, 1] = -8;
            cofactor_input_2[0, 2] = 3;
            cofactor_input_2[0, 3] = 5;
            cofactor_input_2[1, 0] = -3;
            cofactor_input_2[1, 1] = 1;
            cofactor_input_2[1, 2] = 7;
            cofactor_input_2[1, 3] = 3;
            cofactor_input_2[2, 0] = 1;
            cofactor_input_2[2, 1] = 2;
            cofactor_input_2[2, 2] = -9;
            cofactor_input_2[2, 3] = 6;
            cofactor_input_2[3, 0] = -6;
            cofactor_input_2[3, 1] = 7;
            cofactor_input_2[3, 2] = 7;
            cofactor_input_2[3, 3] = -9;
            Assert.Equal(-4071, Matrix.Determinant(cofactor_input_2));
            Assert.Equal(690, Matrix.Cofactor(cofactor_input_2, 0, 0));
            Assert.Equal(447, Matrix.Cofactor(cofactor_input_2, 0, 1));
            Assert.Equal(210, Matrix.Cofactor(cofactor_input_2, 0, 2));
            Assert.Equal(51, Matrix.Cofactor(cofactor_input_2, 0, 3));

            //Implementing Inversion
            Matrix matrix_a = new Matrix(4, 4);
            matrix_a[0, 0] = 6;
            matrix_a[0, 1] = 4;
            matrix_a[0, 2] = 4;
            matrix_a[0, 3] = 4;
            matrix_a[1, 0] = 5;
            matrix_a[1, 1] = 5;
            matrix_a[1, 2] = 7;
            matrix_a[1, 3] = 6;
            matrix_a[2, 0] = 4;
            matrix_a[2, 1] = -9;
            matrix_a[2, 2] = 3;
            matrix_a[2, 3] = -7;
            matrix_a[3, 0] = 9;
            matrix_a[3, 1] = 1;
            matrix_a[3, 2] = 7;
            matrix_a[3, 3] = -6;
            Assert.Equal(-2120, Matrix.Determinant(matrix_a));
            Assert.True(Matrix.IsInvertable(matrix_a));
            Matrix matrix_b = new Matrix(4, 4);
            matrix_b[0, 0] = -4;
            matrix_b[0, 1] = 2;
            matrix_b[0, 2] = -2;
            matrix_b[0, 3] = -3;
            matrix_b[1, 0] = 9;
            matrix_b[1, 1] = 6;
            matrix_b[1, 2] = 2;
            matrix_b[1, 3] = 6;
            matrix_b[2, 0] = 0;
            matrix_b[2, 1] = -5;
            matrix_b[2, 2] = 1;
            matrix_b[2, 3] = -5;
            matrix_b[3, 0] = 0;
            matrix_b[3, 1] = 0;
            matrix_b[3, 2] = 0;
            matrix_b[3, 3] = 0;
            Assert.Equal(0, Matrix.Determinant(matrix_b));
            Assert.False(Matrix.IsInvertable(matrix_b));
            Matrix matrix_c = new Matrix(4, 4);
            matrix_c[0, 0] = -5;
            matrix_c[0, 1] = 2;
            matrix_c[0, 2] = 6;
            matrix_c[0, 3] = -8;
            matrix_c[1, 0] = 1;
            matrix_c[1, 1] = -5;
            matrix_c[1, 2] = 1;
            matrix_c[1, 3] = 8;
            matrix_c[2, 0] = 7;
            matrix_c[2, 1] = 7;
            matrix_c[2, 2] = -6;
            matrix_c[2, 3] = -7;
            matrix_c[3, 0] = 1;
            matrix_c[3, 1] = -3;
            matrix_c[3, 2] = 7;
            matrix_c[3, 3] = 4;
            Assert.Equal(532, Matrix.Determinant(matrix_c));
            Assert.Equal(-160, Matrix.Cofactor(matrix_c, 2, 3));
            Assert.Equal(0, Matrix.Determinant(matrix_b));
            Assert.Equal(105, Matrix.Cofactor(matrix_c, 3, 2));
            Matrix B = Matrix.Inverse(matrix_c);
            Assert.True(Matrix.Equal((double)-160 / 532, B[3, 2]));
            bool compare_test_2 = Matrix.Equal((double)105/532, B[2, 3]);
            Assert.True(compare_test_2);
            Matrix matrix_d = new Matrix(4, 4);
            matrix_d[0, 0] = 0.21805F;
            matrix_d[0, 1] = 0.45113F;
            matrix_d[0, 2] = 0.24060F;
            matrix_d[0, 3] = -0.04511F;
            matrix_d[1, 0] = -0.80827F;
            matrix_d[1, 1] = -1.45677F;
            matrix_d[1, 2] = -0.44361F;
            matrix_d[1, 3] = 0.52068F;
            matrix_d[2, 0] = -0.07895F;
            matrix_d[2, 1] = -0.22368F;
            matrix_d[2, 2] = -0.05263F;
            matrix_d[2, 3] = 0.19737F;
            matrix_d[3, 0] = -0.52256F;
            matrix_d[3, 1] = -0.81391F;
            matrix_d[3, 2] = -0.30075F;
            matrix_d[3, 3] = 0.30639F;
            bool compare_test_3 = matrix_d == B;
            Assert.True(compare_test_3);
            Matrix matrix_e = new Matrix(4, 4);
            matrix_e[0, 0] = 3;
            matrix_e[0, 1] = -9;
            matrix_e[0, 2] = 7;
            matrix_e[0, 3] = 3;
            matrix_e[1, 0] = 3;
            matrix_e[1, 1] = -8;
            matrix_e[1, 2] = 2;
            matrix_e[1, 3] = -9;
            matrix_e[2, 0] = -4;
            matrix_e[2, 1] = 4;
            matrix_e[2, 2] = 4;
            matrix_e[2, 3] = 1;
            matrix_e[3, 0] = -6;
            matrix_e[3, 1] = 5;
            matrix_e[3, 2] = -1;
            matrix_e[3, 3] = 1;

            Matrix matrix_f = new Matrix(4, 4);
            matrix_f[0, 0] = 8;
            matrix_f[0, 1] = 2;
            matrix_f[0, 2] = 2;
            matrix_f[0, 3] = 2;
            matrix_f[1, 0] = 3;
            matrix_f[1, 1] = -1;
            matrix_f[1, 2] = 7;
            matrix_f[1, 3] = 0;
            matrix_f[2, 0] = 7;
            matrix_f[2, 1] = 0;
            matrix_f[2, 2] = 5;
            matrix_f[2, 3] = 4;
            matrix_f[3, 0] = 6;
            matrix_f[3, 1] = -2;
            matrix_f[3, 2] = 0;
            matrix_f[3, 3] = 5;
            Matrix C = matrix_e * matrix_f;
            bool compare_test_4 = matrix_e == (C * Matrix.Inverse(matrix_f));
            Assert.True(compare_test_4);

            Matrix matrix_g = new Matrix(4, 4);
            matrix_g[0, 0] = 8;
            matrix_g[0, 1] = -5;
            matrix_g[0, 2] = 9;
            matrix_g[0, 3] = 2;
            matrix_g[1, 0] = 7;
            matrix_g[1, 1] = 5;
            matrix_g[1, 2] = 6;
            matrix_g[1, 3] = 1;
            matrix_g[2, 0] = -6;
            matrix_g[2, 1] = 0;
            matrix_g[2, 2] = 9;
            matrix_g[2, 3] = 6;
            matrix_g[3, 0] = -3;
            matrix_g[3, 1] = 0;
            matrix_g[3, 2] = -9;
            matrix_g[3, 3] = -4;

            Matrix matrix_h = new Matrix(4, 4);
            matrix_h[0, 0] = -0.15385F;
            matrix_h[0, 1] = -0.15385F;
            matrix_h[0, 2] = -0.28205F;
            matrix_h[0, 3] = -0.53846F;
            matrix_h[1, 0] = -0.07692F;
            matrix_h[1, 1] = 0.12308F;
            matrix_h[1, 2] = 0.02564F;
            matrix_h[1, 3] = 0.03077F;
            matrix_h[2, 0] = 0.35897F;
            matrix_h[2, 1] = 0.35897F;
            matrix_h[2, 2] = 0.43590F;
            matrix_h[2, 3] = 0.92308F;
            matrix_h[3, 0] = -0.69231F;
            matrix_h[3, 1] = -0.692312F;
            matrix_h[3, 2] = -0.76923F;
            matrix_h[3, 3] = -1.92308F;
            Assert.True(Matrix.Inverse(matrix_g) == matrix_h);

            ////SECOND TEST WITH DECIMAL VALUES
            Matrix matrix_j = new Matrix(4, 4);
            matrix_j[0, 0] = 9;
            matrix_j[0, 1] = 3;
            matrix_j[0, 2] = 0;
            matrix_j[0, 3] = 9;
            matrix_j[1, 0] = -5;
            matrix_j[1, 1] = -2;
            matrix_j[1, 2] = -6;
            matrix_j[1, 3] = -3;
            matrix_j[2, 0] = -4;
            matrix_j[2, 1] = 9;
            matrix_j[2, 2] = 6;
            matrix_j[2, 3] = 4;
            matrix_j[3, 0] = -7;
            matrix_j[3, 1] = 6;
            matrix_j[3, 2] = 6;
            matrix_j[3, 3] = 2;

            Matrix matrix_i = new Matrix(4, 4);
            matrix_i[0, 0] = -0.04074F;
            matrix_i[0, 1] = -0.07778F;
            matrix_i[0, 2] = 0.14444F;
            matrix_i[0, 3] = -0.22222F;
            matrix_i[1, 0] = -0.07778F;
            matrix_i[1, 1] = 0.03333F;
            matrix_i[1, 2] = 0.36667F;
            matrix_i[1, 3] = -0.33333F;
            matrix_i[2, 0] = -0.02901F;
            matrix_i[2, 1] = -0.14630F;
            matrix_i[2, 2] = -0.10926F;
            matrix_i[2, 3] = 0.12963F;
            matrix_i[3, 0] = 0.17778F;
            matrix_i[3, 1] = 0.06667F;
            matrix_i[3, 2] = -0.26667F;
            matrix_i[3, 3] = 0.33333F;
            Assert.True(Matrix.Inverse(matrix_j) == matrix_i);
        }
    }
}