using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Domiane.Enums
{
    public enum FileFormat
    {
        [Display(Name = "toBeDefined")]
        ToBeDefined, 
        [Display(Name = ".png")]
        Png,
        [Display(Name = ".jpg")]
        Jpg,
        [Display(Name = ".docx")]
        Docx,
        [Display(Name = ".pdf")]
        Pdf,

    }
}

