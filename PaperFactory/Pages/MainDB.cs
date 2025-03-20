using MySqlConnector;
using PaperFactory.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaperFactory
{
    internal class MainDB : DBConnection
    {
        static public List<Class.Material> materialsList = new List<Class.Material>();
        static public DataTable material_dataTable = new DataTable();
        static public List<Class.Material> GetMaterial()
        {
            try
            {
                string sql3 = "SELECT * FROM VW_MaterialDetails";
                MsCommand.CommandText = sql3;
                material_dataTable.Clear();
                MySqlDataAdapter.SelectCommand = MsCommand;
                MySqlDataAdapter.Fill(material_dataTable);

                foreach (DataColumn column in material_dataTable.Columns)
                {
                    Console.WriteLine(column.ColumnName);  // Или используйте Debug.WriteLine()
                }

                materialsList.Clear();

                //return material;
                foreach (DataRow row in material_dataTable.Rows)
                {
                    Class.Material material = new Class.Material
                    {
                        Type = row["Тип матерала"] == DBNull.Value ? string.Empty : row["Тип матерала"].ToString(),
                        Name = row["Наименование материала"] == DBNull.Value ? string.Empty : row["Наименование материала"].ToString(),
                        Quantity = row["Количеcтво на cкладе"] == DBNull.Value ? 0 : Convert.ToInt32(row["Количеcтво на cкладе"]),
                        SuppliersCount = row["Количеcтво возможных поcтавщиков"] == DBNull.Value ? 0 : Convert.ToInt32(row["Количеcтво возможных поcтавщиков"]),
                        Price = row["Текущая стоимость"] == DBNull.Value ? string.Empty : row["Текущая стоимость"].ToString(),
                        InitialMonthQuantity = row["Количество материалов на начало месяца"] == DBNull.Value ? 0 : Convert.ToInt32(row["Количество материалов на начало месяца"]),
                        Description = row["Описание"] == DBNull.Value ? string.Empty : row["Описание"].ToString(),
                        Image = row["Изображение"] == DBNull.Value ? null : "Image/" + row["Изображение"].ToString().Replace("materials", ""),
                        min_count = row["Минимальное количество"] == DBNull.Value ? string.Empty : row["Минимальное количество"].ToString(),
                        ed_izm = row["Единица измерения"] == DBNull.Value ? string.Empty : row["Единица измерения"].ToString(),
                    };

                    // Добавляем материал в список
                    materialsList.Add(material);
                }

                // Возвращаем список материалов
                return materialsList;
            }
            catch
            {
                MessageBox.Show("Ошибка");
                return null;
            }
        }
    }
}
