namespace DAL;
using BOL;
using System;
using System.Data;

using MySql.Data.MySqlClient;

public class DBManager
{
    public static string conString = @"server=localhost;port=3306;user=root; password=root123;database=playersystem";

    public static List<Player> GetAllPlayers()
    {
        List<Player> allPlayers = new List<Player>();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            con.Open();
            string query = "SELECT * FROM player";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int playerid = int.Parse(reader["playerid"].ToString());
                string? name = reader["name"].ToString();
                string? sports = reader["sports"].ToString();
                int matches = int.Parse(reader["matches"].ToString());

                Player play = new Player
                {
                    Playerid = playerid,
                    Name = name,
                    Sports = sports,
                    Matches = matches,
                };
                allPlayers.Add(play);
            }
        }
        catch (Exception ee)
        {
            Console.WriteLine(ee.Message);
        }

        finally
        {
            con.Close();
        }
        return allPlayers;
    }
    public static Player GetPlayerById(int id)
    {
        Player play = null;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            con.Open();
            string query = "SELECT * FROM player WHERE playerid=" + id;
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {   
                int playerid = int.Parse(reader["playerid"].ToString());
                string? name = reader["name"].ToString();
                string? sports = reader["sports"].ToString();
                int matches = int.Parse(reader["matches"].ToString());

                play = new Player
                {
                    Playerid = playerid,
                    Name = name,
                    Sports = sports,
                    Matches = matches
                };
            }

        }
        catch (Exception ee)
        {
            Console.WriteLine(ee);
        }
        finally
        {
            con.Close();
        }
        return play;
    }

    public static bool Insert(Player player)
    {
        bool status = false;
        string query = "INSERT INTO player(playerid,name,sports,matches) VALUES" +
                    "('" + player.Playerid + "','" + player.Name + "','" + player.Sports + "','" + player.Matches + "')";
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            status = true;
        }
        catch (Exception ee)
        {
            Console.WriteLine(ee.Message);
        }
        finally { con.Close(); }
        return status;
    }
    public static bool Update(Player player)
    {
        bool status = false;
        string query = "UPDATE player SET name='" + player.Name + "',sports='" + player.Sports +
        "',matches='" + player.Matches + "' WHERE playerid=" + player.Playerid;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            status = true;
        }
        catch (Exception ee)
        {
            Console.WriteLine(ee);
        }
        finally { con.Close(); }
        return status;
    }

    public static bool Delete(int id)
    {
        bool status = false;
        string query = "DELETE FROM player WHERE playerid=" + id;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            status = true;
        }
        catch (Exception ee)
        {
            Console.WriteLine(ee);
        }
        finally { con.Close(); }
        return status;
    }
}
