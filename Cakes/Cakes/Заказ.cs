//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cakes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Заказ
    {
        public int Номер { get; set; }
        public System.DateTime Дата { get; set; }
        public string Наименование_заказа { get; set; }
        public string Изделие { get; set; }
        public string Заказчик { get; set; }
        public string Ответственный_менеджер { get; set; }
        public Nullable<decimal> Стоимость { get; set; }
        public Nullable<System.DateTime> Плановая_дата_завершения { get; set; }
        public string Примеры_работ { get; set; }
    
        public virtual Изделие Изделие1 { get; set; }
        public virtual Пользователи Пользователи { get; set; }
    }
}
