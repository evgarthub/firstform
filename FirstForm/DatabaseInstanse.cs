using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace FirstForm
{
    public class DatabaseInstanse
    {
        public static SQLiteConnection ConnectionDB { get; private set; }

        private string sql { get; set; }
        private string formDataName { get; set; }
        private string formDataSurname { get; set; }
        private string formDataEmail { get; set; }
        private string formDataCv_file_name { get; set; }
        private string formDataFile_location_path { get; set; }

        public DatabaseInstanse(IList<string> valueData)
        {
            string path = HttpRuntime.AppDomainAppPath;
            string connectionString = String.Format("Data Source={0}/databaseFile.sqlite; Version=3; FailIfMissing=False", path);

            ConnectionDB = new SQLiteConnection(connectionString);

            PrepareData(valueData);
        }

        public void PrepareData(IList<string> valueData)
        {
            formDataName = valueData[0];
            formDataSurname = valueData[1];
            formDataEmail = valueData[2];
            formDataCv_file_name = valueData[3];
            formDataFile_location_path = @"C:\\uploads\";
        }

        public void AddValue()
        {
            int result = -1;

            ConnectionDB.Open();

            sql = "INSERT INTO formData(name, surname, email, cv_file_name, file_location_path) VALUES (@name, @surname, @email, @cv_file_name, @file_location_path)";

            using (SQLiteCommand cmd = new SQLiteCommand(ConnectionDB))
            {
                cmd.CommandText = sql;
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@name", formDataName);
                cmd.Parameters.AddWithValue("@surname", formDataSurname);
                cmd.Parameters.AddWithValue("@email", formDataEmail);
                cmd.Parameters.AddWithValue("@cv_file_name", formDataCv_file_name);
                cmd.Parameters.AddWithValue("@file_location_path", formDataFile_location_path);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (SQLiteException e)
                {
                    Console.WriteLine(e);
                }
            }

            ConnectionDB.Close();

        }

        public void UpdateValue(IList<string> valueData)
        {
            ConnectionDB.Open();
            sql = "UPDATE formData SET name = @name";
        }

        public void ReadTable()
        {
            int result = -1;
            ConnectionDB.Open();
            sql = "SELECT * FROM formData";
            using (SQLiteCommand cmd = new SQLiteCommand(ConnectionDB))
            {
                cmd.CommandText = sql;
                cmd.Prepare();
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (SQLiteException e)
                {
                    Console.WriteLine(e);
                }
            }
                
        }

    }
}