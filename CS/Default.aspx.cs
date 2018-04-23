using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    const int rows = 5;
    const int seatsInRow = 12;

    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        this.CreateDynamicTable();
        ASPxCallbackPanel1.Controls.Add(table);
    }
    public List<Seat> ListOfSeats {
        get {
            if(Session["ListOfSeats"] == null)
                Session["ListOfSeats"] = new DataSource().PopulateSeats(rows,seatsInRow);
            return Session["ListOfSeats"] as List<Seat>;

        }
    }

    Table table;
    private void CreateDynamicTable() {
        table = new Table();                           
        for(int i = 0; i < rows; i++) {
            TableRow tr = new TableRow();
            TableCell rowHeader = new TableCell();
            rowHeader.CssClass = "label";
            rowHeader.Text = "row " + (i+1).ToString();
            tr.Cells.Add(rowHeader);
            for(int j = 0; j < seatsInRow; j++) {
                TableCell tc = new TableCell();
                int index = i * seatsInRow + j;
                Label txt = new Label();
                txt.ID = "seat|" + index;
                txt.CssClass = "label " + this.GetClassName(ListOfSeats[index].IsFree);
                txt.Text = ListOfSeats[index].Text.ToString();
                txt.Init += Txt_Init;                                              
                tc.Controls.Add(txt);
                tr.Cells.Add(tc);
            }
            table.Rows.Add(tr);
        }
    }

    private void Txt_Init(object sender, EventArgs e) {
        Label txt = sender as Label;
        txt.Attributes.Add("onclick", String.Format("labelClick('{0}');", txt.ClientID));
    }

    public string GetClassName(bool isFree) {
        if(isFree) return "free";
        return "reserved";
    }


    protected void ASPxCallbackPanel1_Callback(object sender, CallbackEventArgsBase e) {
        string[] values = e.Parameter.Split(',');
        foreach(string value in values) {        
            int seat = int.Parse(value.Split('|')[1]); 
            ListOfSeats[seat].IsFree = false;
            ASPxCallbackPanel1.Controls.Remove(table);
            this.CreateDynamicTable();
            ASPxCallbackPanel1.Controls.Add(table);
        }
    }

}