<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="ControlPagosFacturas.Clientes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-start">
            <div class="col-md-4">
                <div class="d-flex ">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title"><%: Title %></h5>
                            <asp:HiddenField ID="id" runat="server" />
                              <div class="mb-2">
                                  <label class="form-label">DPI</label>
                                  <asp:TextBox runat="server"  CssClass="form-control" ID="Txtdpi" ></asp:TextBox>
                                  <asp:Button runat="server" CssClass="btn btn-info" ID="BtnSearch" Text="Buscar" Visible="true" OnClick="BtnSearch_Click" />
                              </div>
                            <div class="mb-2">
                                <label class="form-label">Nombres</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtClienteNombre"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <label class="form-label">Direccion</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtClienteDireccion" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <label class="form-label">Telefono</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TxtClienteTelefono"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <label class="form-label">limite de credito</label>
                                <asp:TextBox runat="server"  CssClass="form-control" ID="TxtClienteSaldo"></asp:TextBox>
                            </div>
                            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Crear" Visible="true" OnClick="BtnCreate_Click"  />
                            <asp:Button runat="server" CssClass="btn btn-warning" ID="BtnUpdate" Text="Editar" Visible="false" OnClick="BtnUpdate_Click"  />
                            <asp:Button runat="server" CssClass="btn btn-danger" ID="BtnDelete" Text="Borrar" Visible="false" OnClick="BtnDelete_Click"  />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                    <asp:GridView CssClass="table table-striped" ID="VistaClientes" runat="server"  Font-Bold="True" ForeColor="Black">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="True"  OnCheckedChanged="chk_buttonCheck"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
