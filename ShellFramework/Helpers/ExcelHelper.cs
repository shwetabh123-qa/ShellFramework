﻿
using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;


namespace ShellFramework.Helpers
{
    public class ExcelHelpers
    {
        private static List<Datacollection> _dataCol = new List<Datacollection>();


        /// <summary>
        /// Storing all the excel values in to the in-memory collections
        /// </summary>
        /// <param name="fileName"></param>
        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    _dataCol.Add(dtTable);
                }
            }
        }

        ///// <summary>
        ///// Reading all the datas from Excelsheet
        ///// </summary>
        ///// <param name="fileName"></param>
        ///// <returns></returns>
        //public static DataTable ExcelToDataTable(string fileName)
        //{
        //    using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
        //    {
        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
        //        {
        //            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
        //            {
        //                ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
        //                {
        //                    UseHeaderRow = true
        //                }
        //            });

        //            //Get all the Tables
        //            DataTableCollection table = result.Tables;
        //            //Store it in DataTable
        //            DataTable resultTable = table["Sheet1"];
        //            //return
        //            return resultTable;
        //        }
        //    }
        //}






        /// <summary>
        /// Reading all the datas from Excelsheet
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string fileName)
        {


            //Open file and return as stream
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            //CreateOpenXmlReader via  ExcelReaderFactory
            IExcelDataReader excelReaderxslx = ExcelReaderFactory.CreateOpenXmlReader(stream);//.xlsx

            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
            //  IExcelDataReader excelReaderxlsx = ExcelReaderFactory.CreateBinaryReader(stream);//.xls

            //for .xlsx
            //Set First Row as Column Name
            excelReaderxslx.IsFirstRowAsColumnNames = true;

            //Return as DataSet
            DataSet result = excelReaderxslx.AsDataSet();



            //Get all the Tables
            DataTableCollection table = result.Tables;


            //Store it in DataTable
            DataTable resultTable = table["Sheet1"];
            //return
            return resultTable;
        }












        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in _dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }



        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }



    }
}