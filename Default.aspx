<%@ Page Title="Consolidado de Pagos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControlPagosFacturas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="d-flex ">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title"><%: Title %></h5>
                             <div class="mb-2">
                                <label class="form-label">CLIENTE CODIGO</label>
                                <asp:DropDownList ID="CLIENT_ID" runat="server">
                                </asp:DropDownList>
                            </div>
                            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnBuscar" Text="Consultar" Visible="true" OnClick="BtnBuscar_Click"/>
                        </div>
                    </div>
                </div>
    </div>

    <div class="row">
         <div class="col-md-4">
             <label class="form-label">Saldo pagado total al credito</label>
             <asp:Label ID="SaldoPagado" runat="server" Text="Saldo pagado al credito total:"></asp:Label>
             <label class="form-label">Saldo al credito aun pendiente de pagar</label>
             <asp:Label ID="SaldoPendiente" runat="server" Text="Saldo al credito aun pendiente"></asp:Label>
        </div>
        
        <div class="col-md-4">
             <label class="form-label">Pagos al credito ya realizados por mes</label>
             <asp:GridView CssClass="table table-striped" ID="VistaConsulta" runat="server"  Font-Bold="True" ForeColor="Black">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
        </div>
          <div class="col-md-4">
             <label class="form-label">Pagos al credito pendientes por mes</label>
             <asp:GridView CssClass="table table-striped" ID="VistaPendientes" runat="server"  Font-Bold="True" ForeColor="Black">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
        </div>
    </div>

</asp:Content>
