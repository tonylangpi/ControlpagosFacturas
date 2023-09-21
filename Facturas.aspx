<%@ Page Title="Venta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Facturas.aspx.cs" Inherits="ControlPagosFacturas.Facturas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container">
        <div class="row justify-content-start">
            <div class="col-md-4">
                <div class="d-flex ">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title"><%: Title %></h5>
                            <asp:HiddenField ID="IdFactura" runat="server" />
                            <asp:HiddenField ID="EstadoFactura" runat="server" />
                              <div class="mb-2">
                                  <label class="form-label">Serie Factura Venta</label>
                                  <asp:TextBox runat="server"  CssClass="form-control" ID="TxtSeriefact" ></asp:TextBox>
                                  <asp:Button runat="server" CssClass="btn btn-info" ID="BtnSearch" Text="Buscar" Visible="true" OnClick="BtnSearch_Click" />
                              </div>
                            <div class="mb-2">
                                <label class="form-label">CLIENTE CODIGO</label>
                                <asp:DropDownList ID="CLIENT_ID" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="mb-2">
                                <label class="form-label">Mes</label>
                                <asp:DropDownList CssClass="dropdown" ID="Mes" runat="server">
                                    <asp:ListItem Value="1">Enero</asp:ListItem>
                                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                                    <asp:ListItem Value="4">Abril</asp:ListItem>
                                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                                    <asp:ListItem Value="6">Junio</asp:ListItem>
                                    <asp:ListItem Value="7">Julio</asp:ListItem>
                                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem CssClass="dropdown-item" Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="mb-2">
                                <label class="form-label">MONTO</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtMontoFact"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <label class="form-label">TIPO FACTURA</label>
                                <asp:DropDownList ID="TipoFact" runat="server">
                                    <asp:ListItem>CONTADO</asp:ListItem>
                                    <asp:ListItem>CREDITO</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:Label ID="mensajeServer" runat="server" Text="...Evaluando"></asp:Label>
                            <asp:Button runat="server" CssClass="btn btn-success" ID="BtnEvaluar" Text="Evaluar credito de cliente" Visible="true" OnClick="BtnEvaluar_Click"  />
                            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Crear" Visible="false" OnClick="BtnCreate_Click"  />
                            <asp:Button runat="server" CssClass="btn btn-warning" ID="BtnUpdate" Text="Pagar" Visible="false" OnClick="BtnUpdate_Click"  />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                    <asp:GridView CssClass="table table-striped" ID="VistaVentas" runat="server"  Font-Bold="True" ForeColor="Black">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="True" OnCheckedChanged="chk_buttonCheck" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
