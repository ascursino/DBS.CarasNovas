<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CarasNovasUserControl.ascx.cs" Inherits="DBS.CarasNovas.CarasNovas.CarasNovasUserControl" %>

<SharePoint:CssRegistration ID="CssRegistration1" runat="server" Name="/_layouts/DBS.CarasNovas/CarasNovas.css"></SharePoint:CssRegistration>
  
        <table class="outterTable">
            <tr>
                <td><!--coluna Esquerda-->                    
                    <table class="innerTable">
                        <tr>
                            <td class="ColunaEsquerda">
                                 <span class="lblNomeResumido">
                                    <asp:Label ID="lblNomeResumido" runat="server" Text="{Nome Resumido}"></asp:Label>                                    
                                 </span>                               
                                 <br />
                                 <p/>
                            </td>
                        </tr>
                        <tr>
                            <td class="ColunaEsquerda">
                                <span class="nomeCampo">Setor:</span>
                                <br />
                                <span class="coluna2"><asp:Label ID="lblSetor" runat="server" Text="{Setor}" CssClass="valorCampo"></asp:Label></span>
                                <p/>
                            </td>                            
                        </tr>
                        <tr>
                            <td class="ColunaEsquerda">
                                <span class="nomeCampo">Ramal:</span>    
                                <br />
                                <span class="coluna2"><asp:Label ID="LblRamal" runat="server" Text="{Ramal}" CssClass="valorCampo"></asp:Label></span>
                                <p/>
                            </td>  
                        </tr>
                        <tr>
                            <td class="ColunaEsquerda">
                                <span class="nomeCampo">Email:</span>
                            </td>                           
                        </tr>
                        </table><!--fim InnerTable-->                                                                              
                </td><!-- fim coluna Esquerda-->
                <td class="ColunaImagem"><!-- coluna Direita-->
                    <asp:Image ID="imgFuncionario" runat="server" CssClass="imgFuncionario" />                    
                </td><!-- fim coluna Direita-->
            </tr>
            <tr>
                <td colspan="2">&nbsp;<asp:Label ID="lblEmail" runat="server" Text="{Email}" CssClass="valorCampo"></asp:Label>            
                </td>
            </tr>
    </table> 

