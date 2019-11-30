<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RockPaperScisors.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

    <script src="../Scripts/jquery-3.4.1.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <title>Rock Paper Scisors</title>
</head>
<body class="container">

    <form id="form1" runat="server" >
        <div class="row" style="margin-top:25px">
            <div class="form-group col-lg-6 col-sm-4 col-xs-12">
                <asp:Label ID="Label1" runat="server" >Nome do Jogador: </asp:Label><br />
                <asp:TextBox ID="PlayerName" class="form-control" runat="server"></asp:TextBox>
            </div>
        
            <div class="form-group col-lg-3 col-sm-4 col-xs-12">
                <asp:Label ID="Label2" runat="server" >Jogada: </asp:Label><br />
                <asp:TextBox ID="Movement" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group col-lg-3 col-sm-4 col-xs-12">
                <asp:Button ID="InsertPlayer" class="btn btn-info btn-block" runat="server" Text="Insert Player" OnClick="InsertPlayer_Click" style="margin-top:20px"/>
            </div>
        </div>
        
        <div class="row" style="margin-top:25px">
            <asp:Table ID="Table1" runat="server" class="table table-responsive">
                <asp:TableHeaderRow ID="Table1HeaderRow"
                    BackColor="LightCyan"
                    runat="server"
                    Width="100%">
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Nome"
                        Width="80%" />
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Jogada"
                        Width="20%" />
                </asp:TableHeaderRow>
                
            </asp:Table>
        </div>

        <div class="row clearfix">
            <div style="float:right">
                <div class="form-group" style="display:inline-block">
                    <asp:Button ID="InsertDefaultPlayers" class="btn btn-info" runat="server" Text="Insert 8 Default Players" OnClick="InsertDefaultPlayers_Click" />
                </div>
                <div class="form-group" style="display:inline-block">
                    <asp:Button ID="StartTournament" class="btn btn-success" runat="server" Text="Start Tournament" OnClick="StartTournament_Click" />
                </div>
            </div>
            
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

    </form>

    
</body>
</html>
