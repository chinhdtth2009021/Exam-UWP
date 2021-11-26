using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Exam_DuongChinh_T2009M1.Models
{
   public class DatabaseMigration
    {
        public static string _databasePath;
        public static string _databaseName = "mycontact.db";
        public static string _createNoteTable = "CREATE TABLE IF NOT EXISTS contacts " +
            "(PhoneNumber NVARCHAR(100) PRIMARY KEY," +
            "Name NVARCHAR(255) NOT NULL,";
        public async static void UpdateDabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync(_databaseName, CreationCollisionOption.OpenIfExists);
            _databasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, _databaseName);
            using (SqliteConnection db = new SqliteConnection($"Filename={_databasePath}"))
            {
                db.Open();
                SqliteCommand createTableNote = new SqliteCommand(_createNoteTable, db);
                createTableNote.ExecuteNonQuery();
            }
        }
    }
}
