using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace MoviesCommunity.Repository
{
    public class MoviesCommunityRepository
    {
        private readonly string connectionString = "Server=INPCD0228\\SQLEXPRESS;DataBase=MoviesCommunity;Integrated Security = SSPI;MultipleActiveResultSets=true";
        public List<CommunitiesModel> GetAllCommunities()
        {
            List<CommunitiesModel> communities = new List<CommunitiesModel>();
            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand("pr_GetAllCommunities", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new CommunitiesModel();
                    item.Id = (Int32)reader["Id"];
                    item.Genre = reader["Genre"].ToString();
                    communities.Add(item);
                }
                reader.Close();
            }

            return communities;
        }

        public List<UserCommunities> GetCommunitiesOfUsers(string userName)
        {
            List<UserCommunities> userCommunities = new List<UserCommunities>();
            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand("pr_GetCommunitiesOfUsers", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new UserCommunities();
                    item.UserName = reader["UserName"].ToString();
                    item.CommunityId = (Int32)reader["CommunityId"];
                    item.Genre = reader["Genre"].ToString();
                    userCommunities.Add(item);
                }
                reader.Close();
            }

            return userCommunities;
        }

        public List<BoardsModel> GetBoardsOfCommunity(int communityId)
        {
            List<BoardsModel> boards = new List<BoardsModel>();
            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand("pr_GetBoardsOfCommunity", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.Add("@CommunityId", SqlDbType.Int).Value = communityId;
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new BoardsModel();
                    item.UserName = reader["UserName"].ToString();
                    item.CommunityId = (Int32)reader["CommunityId"];
                    item.Genre = reader["Genre"].ToString();
                    item.Title = reader["Title"].ToString();
                    item.Content = reader["Content"].ToString();
                    boards.Add(item);
                }
                reader.Close();
            }

            return boards;
        }
    }
}
