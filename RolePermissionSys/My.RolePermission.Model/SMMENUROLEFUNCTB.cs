//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace My.RolePermission.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMMENUROLEFUNCTB
    {
        public int ID { get; set; }
        public Nullable<int> MENUID { get; set; }
        public Nullable<int> FUNC_ID { get; set; }
        public Nullable<int> ROLEID { get; set; }
    
        public virtual SMFUNCTB SMFUNCTB { get; set; }
        public virtual SMMENUTB SMMENUTB { get; set; }
        public virtual SMROLETB SMROLETB { get; set; }
    }
}
