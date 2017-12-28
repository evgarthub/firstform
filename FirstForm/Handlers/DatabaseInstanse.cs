using System;
using System.Data.SQLite;
using System.Configuration;
using System.Collections.Specialized;
using FirstForm.Models;

namespace FirstForm.Handlers
{
    public class DatabaseInstanse
    {
        public static SQLiteConnection ConnectionDB { get; private set; }

        private string Sql { get; set; }
        private FormModel Form { get; set; }
        private string FormDataCv_file_name { get; set; }
        private string FormDataFile_location_path { get; set; }

        public DatabaseInstanse(NameValueCollection valueData, string uploadedFileName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

            ConnectionDB = new SQLiteConnection(connectionString);

            PrepareData(valueData, uploadedFileName);
        }

        public void PrepareData(NameValueCollection valueData, string uploadedFileName)
        {
            Form = new FormModel(valueData);
            
            FormDataCv_file_name = uploadedFileName;
            FormDataFile_location_path = @"C:\uploads";
        }

        public void AddValue()
        {
            int result = -1;

            ConnectionDB.Open();

            Sql = "INSERT INTO formData(name, surname, email, cv_file_name, file_location_path) VALUES (@name, @surname, @email, @cv_file_name, @file_location_path)";

            using (SQLiteCommand cmd = new SQLiteCommand(ConnectionDB))
            {
                cmd.CommandText = Sql;
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@name", Form.DataName);
                cmd.Parameters.AddWithValue("@surname", Form.DataSurname);
                cmd.Parameters.AddWithValue("@email", Form.DataEmail);
                cmd.Parameters.AddWithValue("@cv_file_name", FormDataCv_file_name);
                cmd.Parameters.AddWithValue("@file_location_path", FormDataFile_location_path);

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

        public void UpdateValue()
        {
            int result = -1;
            ConnectionDB.Open();
            Sql = "UPDATE formData SET cv_file_name = @cv_file_name WHERE email = @email AND surname = @surname";

            using (SQLiteCommand cmd = new SQLiteCommand(ConnectionDB))
            {
                cmd.CommandText = Sql;
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@name", Form.DataName);
                cmd.Parameters.AddWithValue("@surname", Form.DataSurname);
                cmd.Parameters.AddWithValue("@email", Form.DataEmail);
                cmd.Parameters.AddWithValue("@cv_file_name", FormDataCv_file_name);
                cmd.Parameters.AddWithValue("@file_location_path", FormDataFile_location_path);

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

        public void ReadTable()
        {
            int result = -1;
            ConnectionDB.Open();
            Sql = "SELECT * FROM formData";

            using (SQLiteCommand cmd = new SQLiteCommand(ConnectionDB))
            {
                cmd.CommandText = Sql;
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

            ConnectionDB.Close();

        }

        public bool CheckRecord(string Filter)
        {
            string FilterString = "WHERE " + Filter;
            int rowsAffected = -1;
            ConnectionDB.Open();
            Sql = "SELECT * FROM formData " + FilterString;

            using (SQLiteCommand cmd = new SQLiteCommand(ConnectionDB))
            {
                cmd.CommandText = Sql;
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@surname", Form.DataSurname);
                cmd.Parameters.AddWithValue("@email", Form.DataEmail);

                try
                {
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (SQLiteException e)
                {
                    Console.WriteLine(e);
                }
            }

            ConnectionDB.Close();

            return rowsAffected>0;
                
        }

    }
}