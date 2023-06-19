using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using NUnit.Framework;

namespace HolidayTests;

[TestFixture]
public class Solution
{
    [Test]
    public void SolveNQueens()
    {
        var n = 5;

        IList<IList<string>> ans = new List<IList<string>>();
        
        for (int i = 0; i < n; i++)
        {
            IList<string> tempans = new List<string>(); 
            tempans.Add("");
            for (int j = 0; j < n; j++)
            {
                if (j == i)
                {
                    tempans[0] = tempans[0] + "Q";
                }
                else
                {
                    tempans[0] = tempans[0] + "."; 
                }
            }

            recursive(n -1, 0, n, tempans, ans, 1);
            
        }

        foreach (IList<string> an in ans)
        {
            foreach (string number in an)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }

    private IList<IList<string>> recursive(int row, int column, int n, IList<string> tempans, IList<IList<string>> ans,
        int queenNum)
    {
        if ((column + 1) * (row + 1) == n * n)
        {
            if (queenNum == n)
            {
                ans.Add(tempans);
            }

            return ans;
        }
        
            if (queenNum <= n)
            {
                if (row == n -1)
                {
                    if (checkSameColumnAndDiagnoseHasQueen(tempans, 0, column + 1, n))
                    {
                        tempans.Add(".");
                        recursive(0, column + 1, n, tempans, ans, queenNum);
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (i == 0)
                            {
                                tempans.Add("Q");
                            }
                            else
                            {
                                tempans[column + 1] = tempans[column + 1] + ".";
                            }
                        }

                        queenNum++;
                        recursive(n - 1, column + 1, n, tempans, ans, queenNum);
                    }

                }
                else
                {
                    if (checkSameColumnAndDiagnoseHasQueen(tempans, row + 1, column, n))
                    {
                        tempans[column] = tempans[column] + ".";
                        recursive(row + 1, column, n, tempans, ans, queenNum);
                    }
                    else
                    {
                        for (int i = row + 1; i < n; i++)
                        {
                            if (i == row + 1)
                            {
                                tempans[column] = tempans[column] + "Q";
                            }
                            else
                            {
                                tempans[column] = tempans[column] + ".";
                            }
                        }

                        queenNum++;
                        recursive(n - 1, column, n, tempans, ans, queenNum);
                    }
                }
            }

            return ans;
    }

    private char getChar(string s, int position)
    {
        var charArr = s.ToCharArray();
        return s[position];
    }


    private bool checkSameColumnAndDiagnoseHasQueen(IList<string> tempans, int row, int column, int n)
    {
     
        var queen = 'Q';

        var checkColumnstart = 0;
        var checkCloumnend = column -1;

        int mem = 1;
        for (int i = column -1; i >= 0; i--) {
            
            if (getChar(tempans[i], row) == queen)
            {
                return true;
            }
            
            if ((row - mem) >= 0 && getChar(tempans[i], row - mem) == queen)
            {
                return true;
            }

            if ((row + mem) <= n-1 && getChar(tempans[i], row + mem) == queen)
            {
                return true; 
            }

            mem++;
            
        }
        

        return false;
    }
    
}