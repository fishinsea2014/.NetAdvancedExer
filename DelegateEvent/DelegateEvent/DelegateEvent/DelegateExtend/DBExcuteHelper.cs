using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvent.DelegateExtend
{
    class DBExcuteHelper
    {
        public void Show()
        {
            string insertSql = "insertSql";
            string deleteSql = "deleteSql";
            string updateSql = "updateSql";
            string searchSql = "searchSql";

            this.Excute(insertSql);
            this.Excute(deleteSql);
            this.Excute(updateSql);
            this.Excute(searchSql);
        }


        /// <summary>
        /// A db sql execution helper
        /// </summary>
        public void Excute(string sql)
        {
            using (SqlConnection conn = new SqlConnection(""))
            {
                //conn.Open();
                //Use to extend transaction 
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                Console.WriteLine($"Execute sql script of {nameof(sql)}={sql}");
            }
        }

        #region ElevenWhere
        /// <summary>
        /// Select data
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> ElevenWhere<TSource>(IEnumerable<TSource> source, Func<TSource, bool> func)
        {
            List<TSource> studentList = new List<TSource>();
            foreach (TSource item in source)
            {
                bool bResult = func.Invoke(item);
                if (bResult)
                {
                    studentList.Add(item);
                }
            }
            return studentList;
        }
        #endregion

        #region ExcuteSql
        public T ExcuteSql<T>(string sql, Func<IDbCommand, T> func)
        {
            using (SqlConnection conn = new SqlConnection(""))
            {
                conn.Open();
                //Use to extend transaction 
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                return func(cmd);
            }
        }
        #endregion

        #region SafeInvoke
        /// <summary>
        /// Commonly handle exception
        /// Encapsulate try catch into a method.
        /// </summary>
        /// <param name="act">Apply to all logics</param>
        public static void SafeInvoke(Action act) //Action is a delegate
        {
            try
            {
                act.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

    }
}
