using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.Data;

namespace FestivalGoed.Model
{
    class Database
    {
        //stap 0: info ophalen uit app.config
        public static ConnectionStringSettings ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MijnConnectionString"];
            }
        }

        //stap 1: connectie leggen met database
        private static DbConnection GetConnection()
        {
            DbConnection con = DbProviderFactories.GetFactory(ConnectionString.ProviderName).CreateConnection();
            con.ConnectionString = ConnectionString.ConnectionString;
            con.Open();
            return con;
        }

        //Stap 2: connectie sluiten met database
        public static void ReleaseConnection(DbConnection con)
        {
            if (con != null)
            {
                con.Close();
                con = null;
            }
        }

        //stap 3: command opstellen (boodschappenlijstje) SQL string + parameters
        //keywords params -> als er geen parameters zijn hoeft er niets doorgegeven te worden (enkel een sql string)
        private static DbCommand BuildCommand(String sql, params DbParameter[] parameters)
        {
            //command opvragen aan connectie
            DbCommand command = GetConnection().CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;

            //parameters doorgeven
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            return command;
        }

        //stap 3a: aanmaken van een parameter
        public static DbParameter AddParameter(string naam, Object value)
        {
            DbParameter parameter = DbProviderFactories.GetFactory(ConnectionString.ProviderName).CreateParameter();
            parameter.ParameterName = naam;
            parameter.Value = value;
            return parameter;
        }

        //stap 4a: select statements: info ophalen
        public static DbDataReader GetData(string sql, params DbParameter[] parameters)
        {
            DbCommand command = BuildCommand(sql, parameters);
            DbDataReader reader = null;

            try
            {
                //datareader opvragen. Als de reader alle informatie doorlopen heeft, wordt automatich de connectie gesloten
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (reader != null) reader.Close();
                if (command != null) ReleaseConnection(command.Connection);
                throw ex; //fout doorgeven aan de aanroep mthode
            }
        }

        //stap 4b: INSERT/DELETE/UPDATE: database gaan manipuleren
        public static int ModifyData(String sql, params DbParameter[] parameters)
        {
            DbCommand command = BuildCommand(sql, parameters);
            try
            {
                int aantalGewijzigdeRijen = command.ExecuteNonQuery();
                return aantalGewijzigdeRijen;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (command != null) ReleaseConnection(command.Connection);
                throw ex;
            }
        }

        //stap 5: transactie aanmaken
        public static DbTransaction BeginTransaction()
        {
            DbConnection con = null;
            try
            {
                //connectie opvragen
                con = GetConnection();
                //connectie instellen
                return con.BeginTransaction();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        //stap 6: command binnen een transactie aanmaken
        private static DbCommand BuildCommand(DbTransaction trans, String sql, params DbParameter[] parameters)
        {
            //command opvragen aan connectie
            DbCommand command = BeginTransaction().Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;

            //parameters doorgeven
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            return command;
        }

        //stap 7a: SELECT binnen een transactie
        public static DbDataReader GetData(DbTransaction trans, string sql, params DbParameter[] parameters)
        {
            DbCommand command = BuildCommand(trans, sql, parameters);
            DbDataReader reader = null;

            try
            {
                //datareader opvragen. Als de reader alle informatie doorlopen heeft, wordt automatich de connectie gesloten
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (reader != null) reader.Close();
                if (command != null) ReleaseConnection(command.Connection);
                throw ex; //fout doorgeven aan de aanroep mthode
            }
        }

        public static int ModifyData(DbTransaction trans, String sql, params DbParameter[] parameters)
        {
            DbCommand command = BuildCommand(trans, sql, parameters);
            try
            {
                int aantalGewijzigdeRijen = command.ExecuteNonQuery();
                return aantalGewijzigdeRijen;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (command != null) ReleaseConnection(command.Connection);
                throw ex;
            }
        }

    }
}
