using System;
using System.Collections.Generic;
using System.Messaging;
using System.Web.UI;
using System.Web.UI.WebControls;
using RockPaperScisors.Entities;
using RockPaperScisors.Entities.Enums;
using RockPaperScisors.Entities.Exceptions;

namespace RockPaperScisors
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["NUMBER_OF_PLAYERS"] = 0;
            }
        }

        protected void StartTournament_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(Session["NUMBER_OF_PLAYERS"]);
            if(count > 1)
            {
                Table1.Rows.Clear();
                List<Player> players = new List<Player>();
                for (int i = 0; i < count; i++)
                {
                    string[] separador = { "$_$" };
                    string[] player = Session["PLAYER_" + i].ToString().Split(separador, StringSplitOptions.RemoveEmptyEntries);

                    Player player1 = new Player(player[0]);
                    player1.ParseMovement(player[1].ToUpper());
                    players.Add(player1);
                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    cell1.Text = player[0];
                    cell2.Text = player[1].ToUpper();
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    Table1.Rows.Add(row);
                }
                Player winner = Tournament.RpsTournamentWinner(players);

                lblModalTitle.Text = "Championship Modal";
                lblModalBody.Text = "Tournament winner was: " + winner.Name + " <br>With the move: " + winner.Movement;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
            else
            {
                lblModalTitle.Text = "Validation Modal";
                lblModalBody.Text = "A minimum of 2 players are required to start the tournament.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
                PreencheTabela();
            }
            
        }

        protected void InsertPlayer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PlayerName.Text) || string.IsNullOrEmpty(Movement.Text))
            {
                lblModalTitle.Text = "Validation Modal";
                lblModalBody.Text = "All the fields are required";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
                PreencheTabela();
            }
            else
            {
                try
                {
                    Player player = new Player(PlayerName.Text);
                    player.ParseMovement(Movement.Text);
                    AddPlayer(PlayerName.Text, Movement.Text);
                    PlayerName.Text = "";
                    Movement.Text = "";
                }
                catch (NoSuchStrategyException exc)
                {
                    lblModalTitle.Text = "Validation Modal";
                    lblModalBody.Text = exc.Message;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
            }
        }

        protected void InsertDefaultPlayers_Click(object sender, EventArgs e)
        {
            Player player1 = new Player("Armando");
            player1.ParseMovement("P");
            Player player2 = new Player("Dave");
            player2.ParseMovement("S");
            Player player3 = new Player("Richard");
            player3.ParseMovement("R");
            Player player4 = new Player("Michael");
            player4.ParseMovement("S");
            Player player5 = new Player("Allen");
            player5.ParseMovement("S");
            Player player6 = new Player("Omer");
            player6.ParseMovement("P");
            Player player7 = new Player("David E.");
            player7.ParseMovement("R");
            Player player8 = new Player("Richard X.");
            player8.ParseMovement("P");

            AddPlayer(player1.Name, player1.Movement.ToString());
            AddPlayer(player2.Name, player2.Movement.ToString());
            AddPlayer(player3.Name, player3.Movement.ToString());
            AddPlayer(player4.Name, player4.Movement.ToString());
            AddPlayer(player5.Name, player5.Movement.ToString());
            AddPlayer(player6.Name, player6.Movement.ToString());
            AddPlayer(player7.Name, player7.Movement.ToString());
            AddPlayer(player8.Name, player8.Movement.ToString());

            
        }

        private void AddPlayer(string name, string movement)
        {
            int count = Convert.ToInt32(Session["NUMBER_OF_PLAYERS"]);

            Session["PLAYER_" + count] = name + "$_$" + movement;
            Session["NUMBER_OF_PLAYERS"] = count + 1;

            PreencheTabela();


            lblModalTitle.Text = "Success !!";
            lblModalBody.Text = "Player has been successfully inserted";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }

        private void PreencheTabela()
        {
            int count = Convert.ToInt32(Session["NUMBER_OF_PLAYERS"]);
            Table1.Rows.Clear();

            for (int i = 0; i < count; i++)
            {
                string[] separador = { "$_$" };
                string[] player = Session["PLAYER_" + i].ToString().Split(separador, StringSplitOptions.RemoveEmptyEntries);

                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell1.Text = player[0];
                cell2.Text = player[1].ToUpper();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                Table1.Rows.Add(row);
            }
        }
    }
}