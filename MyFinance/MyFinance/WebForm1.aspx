﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MyFinance.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox runat="server" ID="txt" TextMode="MultiLine" Rows="10" Width="500px"></asp:TextBox>
    <asp:Button runat="server" ID="btn" Text="执行" onclick="btn_Click" />
    <asp:Label runat="server" ID="lblMessage"></asp:Label>
    </div>
    </form>
</body>
</html>
