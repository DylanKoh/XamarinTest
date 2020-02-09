using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinTest.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
