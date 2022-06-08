using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text.Language;

/// <summary>
/// <see cref="Size"/> 列挙型は、分割サイズを示します。
/// </summary>
public enum Size : int
{
    /// <summary>
    /// 分割数＝１ (n = 1)
    /// </summary>
    Uni = 1,
    /// <summary>
    /// 分割数＝２ (n = 2)
    /// </summary>
    Bi = 2,
    /// <summary>
    /// 分割数＝３ (n = 3)
    /// </summary>
    Tri = 3,
    /// <summary>
    /// 分割数＝４ (n = 4)
    /// </summary>
    n4 = 4,
    /// <summary>
    /// 分割数＝５ (n = 5)
    /// </summary>
    n5 = 5,
}
