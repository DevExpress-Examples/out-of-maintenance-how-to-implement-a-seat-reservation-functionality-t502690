using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataSource
/// </summary>
public class DataSource {
    public List<Seat> PopulateSeats(int rows, int seatsInRow) {
        List<Seat> list = new List<Seat>();
        for(int i = 0; i <rows ; i++) {
            for(int j = 0; j < seatsInRow; j++) {
                list.Add(new Seat() { IsFree = true, Text = i * seatsInRow + j + 1 });
            }
        }
        return list;
    }

}