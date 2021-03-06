﻿using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;

namespace CS.Model {
    public class MyModel {

        public static DataTable GetProducts() {
            DataTable dataTableProducts = new DataTable();
            using (OleDbConnection connection = GetConnection()) {
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Empty, connection);
                adapter.SelectCommand.CommandText = "SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice] FROM [Products]";

                adapter.Fill(dataTableProducts);


            }
            return dataTableProducts;
        }

        public static DataTable GetCustomers() {
            DataTable dataTablCustomers = new DataTable();
            using (OleDbConnection connection = GetConnection()) {
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Empty, connection);
                adapter.SelectCommand.CommandText = "SELECT [CustomerID], [CompanyName] FROM [Customers]";

                adapter.Fill(dataTablCustomers);


            }
            return dataTablCustomers;
        }
        static OleDbConnection GetConnection() {
            OleDbConnection connection = new OleDbConnection() { ConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", HttpContext.Current.Server.MapPath("~/App_Data/nwind.mdb")) };
            return connection;
        }

    }

    public class MyViewModel {

        public DataTable Products { get; set; }

        public DataTable Customers { get; set; }
    }
}