//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int ID_booking { get; set; }
        public string Booking_date { get; set; }
        public int Client_ID { get; set; }
        public int Dish_ID { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
