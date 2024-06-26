﻿using System;
using System.Collections;
using System.Runtime.InteropServices;
using xl = Microsoft.Office.Interop.Excel;

namespace ShellTest.Helpers
{
    
        class ExcelHelperNew
        {
            xl.Application xlApp = null;
            xl.Workbooks workbooks = null;
            xl.Workbook workbook = null;
            Hashtable sheets;
            public string xlFilePath;

            public ExcelHelperNew(string xlFilePath)
            {
                this.xlFilePath = xlFilePath;
            }

            public void OpenExcel()
            {
                xlApp = new xl.Application();
                workbooks = xlApp.Workbooks;
                workbook = workbooks.Open(xlFilePath);
                sheets = new Hashtable();
                int count = 1;
                // Storing worksheet names in Hashtable.
                foreach (xl.Worksheet sheet in workbook.Sheets)
                {
                    sheets[count] = sheet.Name;
                    count++;
                }
            }

            public void CloseExcel()
            {
                workbook.Close(false, xlFilePath, null); // Close the connection to workbook
                Marshal.FinalReleaseComObject(workbook); // Release unmanaged object references.
                workbook = null;

                workbooks.Close();
                Marshal.FinalReleaseComObject(workbooks);
                workbooks = null;

                xlApp.Quit();
                Marshal.FinalReleaseComObject(xlApp);
                xlApp = null;
            }

            public bool SetCellData(string sheetName, string colName, int rowNumber, string value)
            {
                OpenExcel();

                int sheetValue = 0;
                int colNumber = 0;

                try
                {
                    if (sheets.ContainsValue(sheetName))
                    {
                        foreach (DictionaryEntry sheet in sheets)
                        {
                            if (sheet.Value.Equals(sheetName))
                            {
                                sheetValue = (int)sheet.Key;
                            }
                        }

                        xl.Worksheet worksheet = null;
                        worksheet = workbook.Worksheets[sheetValue] as xl.Worksheet;
                        xl.Range range = worksheet.UsedRange;

                        for (int i = 1; i <= range.Columns.Count; i++)
                        {
                            string colNameValue = Convert.ToString((range.Cells[1, i] as xl.Range).Value2);
                            if (colNameValue.ToLower() == colName.ToLower())
                            {
                                colNumber = i;
                                break;
                            }
                        }

                        range.Cells[rowNumber, colNumber] = value;

                        workbook.Save();
                        Marshal.FinalReleaseComObject(worksheet);
                        worksheet = null;

                        CloseExcel();
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }

        }
    }
