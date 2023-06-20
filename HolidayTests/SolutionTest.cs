using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HolidayTests;

[TestFixture]
public class Solution
{
    [Test]
    public void SolveNQueens()
    {
        var n = 8;

        IList<IList<string>> ans = new List<IList<string>>();
        IList<string> tempans = new List<string>();

        for (var column = 0; column < n; column++)
        {
            tempans.Add(".");
            for (var row = 1; row < n; row++) tempans[column] = tempans[column] + ".";
        }

        recursive(0, n, tempans, ans);

        foreach (var an in ans)
        {
            foreach (var number in an) Console.Write(number + " ");
            Console.WriteLine();
        }
    }

    private IList<IList<string>> recursive(int row, int n, IList<string> tempans, IList<IList<string>> ans)
    {
        if (row == n)
        {
            IList<string> solution = new List<string>();
            foreach (var rowans in tempans) solution.Add(rowans);

            ans.Add(solution);
            return ans;
        }

        for (var column = 0; column < n; column++)
            if (!checkSameRowAndDiagnoseHasQueen(tempans, row, column, n))
            {
                var chararray = tempans[column].ToCharArray();
                chararray[row] = 'Q';
                var str = new string(chararray);
                tempans[column] = str;

                ans = recursive(row + 1, n, tempans, ans);

                chararray[row] = '.';
                str = new string(chararray);
                tempans[column] = str;
            }


        return ans;
    }

    private char getChar(string s, int position)
    {
        var charArr = s.ToCharArray();
        return s[position];
    }


    private bool checkSameRowAndDiagnoseHasQueen(IList<string> tempans, int row, int column, int n)
    {
        var queen = 'Q';

        var mem = 1;
        var tempcol1 = column;
        var tempcol2 = column;
        for (var i = 0; i <= row; i++)
        {
            if (getChar(tempans[column], i) == queen) 
                return true;

            if (row - mem >= 0 && tempcol1 - 1 >= 0 && getChar(tempans[tempcol1 - 1], row - mem) == queen) return true;

            if (row - mem >= 0 && tempcol2 + 1 <= n - 1 && getChar(tempans[tempcol2 + 1], row - mem) == queen)
                return true;

            mem++;
            tempcol1--;
            tempcol2++;
        }


        return false;
    }
}