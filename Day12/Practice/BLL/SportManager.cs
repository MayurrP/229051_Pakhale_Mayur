namespace BLL;
using BOL;
using DAL;

public class SportManager
{
    public List<Player> GetAllPlayers(){
        List<Player> allPlayers = new List<Player>();
        allPlayers = DBManager.GetAllPlayers();
        return allPlayers;
    }
    public Player GetPlayerById(int id){
        Player play = new Player();
        play = DBManager.GetPlayerById(id);
        return play;
    }
    public bool Insert(Player play){
        bool status = DBManager.Insert(play);
        return status;
    }
    public bool Update(Player play){
        bool status = DBManager.Update(play);
        return status;
    }
    public bool Delete(int id){
        Player play = new Player();
        bool status = DBManager.Delete(id);
        return status;
    }
}
