<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .free {
            background-color: lightgreen;
        }

        .selected {
            background-color: yellow;
        }

        .reserved {
            background-color: lightcoral;
        }

        .label {
            margin: 5px;
            font-size: 16px;
            display: block;
        }

        .description {
            width: 20px;
            height: 20px;
        }

    </style>
    <script type="text/javascript">
        var selectedElements = [];
        function Reserve(s, e) {
            if (selectedElements.length > 0) callback.PerformCallback(selectedElements.toString());
            selectedElements = [];
        }
        function labelClick(id) {
            var el = document.getElementById(id);
            if (el.classList.contains('free') && !el.classList.contains('selected')) {
                el.classList.add('selected');
                selectedElements.push(id);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Reserve" AutoPostBack="False">
                <ClientSideEvents Click="Reserve" />
            </dx:ASPxButton>
            <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" ClientInstanceName="callback" OnCallback="ASPxCallbackPanel1_Callback">
                <PanelCollection>
                    <dx:PanelContent runat="server">
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>
            <table>
                <tr>
                    <td class="description free"></td>
                    <td>Free seat.</td>
                </tr>
                <tr>
                    <td class="description selected"></td>
                    <td>Ready to reserve.</td>
                </tr>
                <tr>
                    <td class="description reserved"></td>
                    <td>Reserved seats.</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
