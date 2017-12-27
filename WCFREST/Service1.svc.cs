using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //todo denne skal udkommenteres når SQL påbegyndes. 
        #region Listen til at kører "lokalt"

        private static List<ChangeClassName> ChangeList = new List<ChangeClassName>()
        {
            new ChangeClassName(1, "Navn", "Type", 2.5, 100,new DateTime(2017,12,27,20,50,00))
        };

        #endregion
        //todo denne skal udkommenteres når SQL påbegyndes.
        #region CRUD kald til den statiske liste.

        /// <summary>
        /// Dette tilføjer et objekt til listen.
        /// </summary>
        /// <param name="tempChange"></param>
        /// <returns></returns>
        public HttpStatusCode AddChange(ChangeClassName tempChange)
        {
            ChangeList.Add(tempChange);
            if (ChangeList.Contains(tempChange))
            {
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.NotModified;

        }
        /// <summary>
        /// Dette viser kun et objekt.
        /// </summary>
        /// <returns></returns>
        public ChangeClassName OneObjekt(string id)
        {
            int idTal = int.Parse(id);
            ChangeClassName tempObjekt = ChangeList.FirstOrDefault(b => b.Id == idTal);
            if (tempObjekt == null)
            {
                return null;
            }
            return tempObjekt;
        }

        /// <summary>
        /// Dette returnere listen over alle Change
        /// </summary>
        /// <returns></returns>
        public List<ChangeClassName> AllChange()
        {
            return ChangeList;
        }
        /// <summary>
        /// Dette tillader at redigere i objektet.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tempChange"></param>
        /// <returns></returns>
        public ChangeClassName EditClass(string id, ChangeClassName tempChange)
        {
            int idTal = int.Parse(id);
            ChangeClassName eksisterendeObjekt = ChangeList.FirstOrDefault(b => b.Id == idTal);

            if (eksisterendeObjekt == null) return null;

            eksisterendeObjekt.ChangeDouble = tempChange.ChangeDouble;
            eksisterendeObjekt.ChangeInteger = tempChange.ChangeInteger;
            eksisterendeObjekt.ChangeString = tempChange.ChangeString;
            eksisterendeObjekt.ChangeString1 = tempChange.ChangeString1;
            eksisterendeObjekt.DateAndTime = tempChange.DateAndTime;

            return eksisterendeObjekt;
        }
        /// <summary>
        /// Dette tillader at fjerne et objekt fra listen.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpStatusCode RemoveClass(string id)
        {
            ChangeClassName tempObjekt = OneObjekt(id);
            if (tempObjekt != null)
            {
                ChangeList.Remove(tempObjekt);
                return HttpStatusCode.Accepted;
            }
            return HttpStatusCode.Conflict;
        }
        #endregion

        #region SQL kald til database.
        //Dette tilhører database kald via SQL.
        /// <summary>
        /// Dette laver et kald til databasen og returnere en liste hvor alle objekter er.
        /// </summary>
        /// <returns></returns>
        //    public List<ChangeClassName> AllChange()
        //    {
        //        SqlCommand GetAllElements = new SqlCommand("SELECT * FROM Eksamen", DatabaseService.SqlCon());
        //        SqlDataReader reader = GetAllElements.ExecuteReader();
        //        DatabaseService.SqlCon().Close();

        //        return Util.ListCreator(reader);
        //    }
        //    /// <summary>
        //    /// Dette sender et objekt tilbage med den givne id
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <returns></returns>
        //    public ChangeClassName OneObjekt(string id)
        //    {
        //        int idTal = int.Parse(id);
        //        SqlCommand GetAllElements = new SqlCommand($"SELECT * FROM Eksamen WHERE Id = @Id", DatabaseService.SqlCon());
        //        GetAllElements.Parameters.AddWithValue("@Id", idTal);
        //        SqlDataReader reader = GetAllElements.ExecuteReader();
        //        DatabaseService.SqlCon().Close();

        //        ChangeClassName tempObjekt = new ChangeClassName();
        //        while (reader.Read())
        //        {
        //            tempObjekt = Util.ObjectCreator(reader);
        //        }


        //        return tempObjekt;

        //    }
        //    /// <summary>
        //    /// Denne tilføjer et objekt til databasen.
        //    /// </summary>
        //    /// <param name="tempChange"></param>
        //    /// <returns></returns>
        //    public HttpStatusCode AddChange(ChangeClassName tempChange)
        //    {
        //        SqlCommand IndsætObjekt =
        //            new SqlCommand(
        //                "insert into Eksamen(ChangeString, ChangeString1, ChangeDouble, ChangeInteger, DateAndTime) values (@ChangeString, @ChangeString1, @ChangeDouble, @ChangeInteger, @DateAndTime)",
        //                DatabaseService.SqlCon());

        //        IndsætObjekt.Parameters.AddWithValue("@ChangeString", tempChange.ChangeString);
        //        IndsætObjekt.Parameters.AddWithValue("@ChangeString1", tempChange.ChangeString1);
        //        IndsætObjekt.Parameters.AddWithValue("@ChangeDouble", tempChange.ChangeDouble);
        //        IndsætObjekt.Parameters.AddWithValue("@ChangeInteger", tempChange.ChangeInteger);
        //        IndsætObjekt.Parameters.AddWithValue("@DateAndTime", tempChange.DateAndTime);

        //        if (IndsætObjekt.ExecuteNonQuery() != 0)
        //        {
        //            DatabaseService.SqlCon().Close();
        //            return HttpStatusCode.Created;
        //        }

        //        DatabaseService.SqlCon().Close();
        //        return HttpStatusCode.BadRequest;


        //}
        //    /// <summary>
        //    /// Dette tillader at redigere i et objekt.
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <param name="tempChange"></param>
        //    /// <returns></returns>
        //    public ChangeClassName EditClass(string id, ChangeClassName tempChange)
        //    {
        //        int idTal = int.Parse(id);
        //        SqlCommand RedigerObjekt =
        //            new SqlCommand(
        //                "Update Eksamen set ChangeString = @ChangeString, ChangeString1 = @ChangeString1, ChangeDouble = @ChangeDouble, ChangeInteger = @ChangeInteger, DateAndTime = @DateAndTime WHERE Id = @Id",
        //                DatabaseService.SqlCon());
        //        RedigerObjekt.Parameters.AddWithValue("@Id", idTal);
        //        RedigerObjekt.Parameters.AddWithValue("@ChangeString", tempChange.ChangeString);
        //        RedigerObjekt.Parameters.AddWithValue("@ChangeString1", tempChange.ChangeString1);
        //        RedigerObjekt.Parameters.AddWithValue("@ChangeDouble", tempChange.ChangeDouble);
        //        RedigerObjekt.Parameters.AddWithValue("@ChangeInteger", tempChange.ChangeInteger);
        //        RedigerObjekt.Parameters.AddWithValue("@DateAndTime", tempChange.DateAndTime);

        //        if (RedigerObjekt.ExecuteNonQuery() != 0)
        //        {
        //            DatabaseService.SqlCon().Close();
        //            return OneObjekt(id);
        //        }

        //        DatabaseService.SqlCon().Close();
        //        return null;

        //    }

        //    public HttpStatusCode RemoveClass(string id)
        //    {
        //        int idTal = int.Parse(id);
        //        SqlCommand GetAllElements = new SqlCommand($"Delete FROM Eksamen WHERE Id = @Id", DatabaseService.SqlCon());
        //        GetAllElements.Parameters.AddWithValue("@Id", idTal);
        //        SqlDataReader reader = GetAllElements.ExecuteReader();
        //        DatabaseService.SqlCon().Close();

        //        return HttpStatusCode.Accepted;
        //    }
        #endregion
    }
}
