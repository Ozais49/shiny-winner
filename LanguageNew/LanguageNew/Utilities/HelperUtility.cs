using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LanguageNew.Utilities
{
    public static class HelperUtility
    {
        public static List<T> ToList<T>(this DataTable Table) where T : class, new()
        {
            if (!IsValidDatatable(Table))
                return new List<T>();

            Type classType = typeof(T);
            IList<PropertyInfo> propertyList = classType.GetProperties();

            // Parameter class has no public properties.
            if (propertyList.Count == 0)
                return new List<T>();

            List<string> columnNames = Table.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToList();

            List<T> result = new List<T>();
            try
            {
                foreach (DataRow row in Table.Rows)
                {
                    T classObject = new T();
                    foreach (PropertyInfo property in propertyList)
                    {
                        if (property != null && property.CanWrite)   // Make sure property isn't read only
                        {
                            if (columnNames.Contains(property.Name))  // If property is a column name
                            {
                                if (row[property.Name] != System.DBNull.Value)   // Don't copy over DBNull
                                {
                                    var type = Nullable.GetUnderlyingType(property.PropertyType);
                                    object propertyValue = System.Convert.ChangeType(
                                            row[property.Name],
                                          type == null ? property.PropertyType : type
                                        );
                                    property.SetValue(classObject, propertyValue, null);
                                }
                            }
                        }
                    }
                    result.Add(classObject);
                }
                return result;
            }
            catch
            {
                return new List<T>();
            }
        }
        /// <summary>
        /// Converts data table to single class object
        /// </summary>
        /// <typeparam name="T">Return type object</typeparam>
        /// <param name="Table">Datatable containing row from database</param>
        /// <returns>List of passsed object type</returns>
        public static T ToSingle<T>(this DataTable Table) where T : class, new()
        {
            if (!IsValidDatatable(Table))
                return new T();

            Type classType = typeof(T);
            IList<PropertyInfo> propertyList = classType.GetProperties();

            // Parameter class has no public properties.
            if (propertyList.Count == 0)
                return new T();

            List<string> columnNames = Table.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToList();

            T result = new T();
            try
            {
                foreach (DataRow row in Table.Rows)
                {
                    T classObject = new T();
                    foreach (PropertyInfo property in propertyList)
                    {
                        if (property != null && property.CanWrite)   // Make sure property isn't read only
                        {
                            if (columnNames.Contains(property.Name))  // If property is a column name
                            {
                                if (row[property.Name] != System.DBNull.Value)   // Don't copy over DBNull
                                {
                                    var type = Nullable.GetUnderlyingType(property.PropertyType);
                                    object propertyValue = System.Convert.ChangeType(
                                            row[property.Name],
                                           type == null ? property.PropertyType : type
                                        );
                                    property.SetValue(classObject, propertyValue, null);
                                }
                            }
                        }
                    }
                    result = classObject;
                }
                return result;
            }
            catch (Exception ex)
            {
                return new T();
            }
        }
        private static bool IsValidDatatable(DataTable Table, bool IgnoreRows = false)
        {
            if (Table == null) return false;
            if (Table.Columns.Count == 0) return false;
            if (!IgnoreRows && Table.Rows.Count == 0) return false;
            return true;
        }
    }
}