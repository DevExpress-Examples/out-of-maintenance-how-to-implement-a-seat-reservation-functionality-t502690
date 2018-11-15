<!-- default file list -->
*Files to look at*:

* [DataSource.cs](./CS/App_Code/DataSource.cs) (VB: [DataSource.vb](./VB/App_Code/DataSource.vb))
* [Seat.cs](./CS/App_Code/Seat.cs) (VB: [Seat.vb](./VB/App_Code/Seat.vb))
* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx](./VB/Default.aspx))
<!-- default file list end -->
# How to implement a seat reservation functionality


The sample illustrates how to create a seat reservation functionality using the Table control with Label controls and ASPxCallbackPanel.<br><br>1. Create various css classes to assign them to a Label control  depending on  a seat status. The Page css style includes three classes:<br><em>the free css class</em> is applied to Label if a seat is free;<br><em>the selected css</em> class is applied to Label that is clicked by user;<br><em>the reserved css</em> class is applied to Label if a seat is reserved;<br><br>2. Implement the Seat class with IsFree and Text properties. IsFree returns true if a seat is free and false if it’s reserved. Text returns a number of a seat. Create a collection of Seat objects to present a full list of seats.<br><br>3. For every Seat object from the collection, generate a Label control in the Table control. Depending on the Seat.IsFree property, assign the necessary css class to the Label.<br><br>4. To process clicked Label controls, subscribe to the Label client onclick event. Do it in the Label.Init event handler to pass the final ClientID as a function parameter.<br><br>5. On the client side, add the selected element id to a javascript array. When the Reserve button is clicked, call the ASPxClientCallbackPanel.PerformCallback and pass that collection to the server.<br><br>6. In the ASPxCallbackPanel.Callback event handler,  iterate the passed collection and change the Seat.IsFree property to false for necessary Seat objects of the List<Seat> collection. Recreate the Table control.

<br/>


