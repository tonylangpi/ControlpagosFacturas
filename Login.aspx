<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ControlPagosFacturas.Login" %>

<!DOCTYPE html>

<html lang="es">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>LOGIN</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        <div class="container">
            <h1>Formulario de inicio de sesión</h1>
            <div class="mb-3">
                <label for="email" class="form-label">Correo electrónico</label>
                <asp:TextBox ID="txtcorreo" TextMode="Email" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="password" class="form-label">Contraseña</label>
                 <asp:TextBox ID="txtclave" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="ingresar" class="btn btn-primary" runat="server" Text="INGRESAR" OnClick="ingresar_Click" />
            <asp:Label ID="Label1" runat="server" Text="...Esperando Datos del servidor"></asp:Label>
        </div>
    </form>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/Scripts/bootstrap.js") %>
    </asp:PlaceHolder>
</body>
</html>
