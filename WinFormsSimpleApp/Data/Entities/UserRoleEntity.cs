﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WinFormsSimpleApp.Data.Entities
{
    [Table("tblUserRoles")]
    public class UserRoleEntity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual RoleEntity Role { get; set; }
    }
}
