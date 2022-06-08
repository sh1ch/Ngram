using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text.Language;

/// <summary>
/// <see cref="Ngram"/> クラスは、任意の文字列を n (1≦n≦3) 個の文字で分割するテキスト分割法です。
/// </summary>
public static class Ngram
{
    /// <summary>
    /// <paramref name="text1"/> と <paramref name="text2"/> を比較したときのテキスト類似度 (0≦n≦1) を取得します。
    /// </summary>
    /// <param name="text1">比較するテキスト。</param>
    /// <param name="text2">比較するテキスト。</param>
    /// <param name="parseSize">分割する文字数。</param>
    /// <returns>テキストの類似度。(0 = まったく一致していない, 1 = 完全一致)</returns>
    public static double Compare(string text1, string text2, Size parseSize = Size.Tri)
    {
        var temp1 = ParseToCharArray(text1, parseSize).ToArray();
        var temp2 = ParseToCharArray(text2, parseSize).ToArray();

        if (temp1.Length == 0 || temp2.Length == 0)
        {
            return 0;
        }

        char[][] data1;
        char[][] data2;

        // データ数が多いほうを data1 に格納する
        if (temp1.Length > temp2.Length)
        {
            data1 = temp1;
            data2 = temp2;
        }
        else
        {
            data1 = temp2;
            data2 = temp1;
        }

        var dataCount = data1.Length + data2.Length;
        var sameCount = 0;
        
        for (int i = 0; i < data1.Length; i++)
        {
            for (int j = 0; j < data2.Length; j++)
            {
                if (data1[i].SequenceEqual(data2[j]))
                {
                    sameCount++;
                    break;
                }
            }
        }

        return (double)sameCount / (dataCount - sameCount);
    }

    /// <summary>
    /// 指定したテキストを N-gram 分割し、<see cref="char[]"/> 型のコレクションを取得します。
    /// </summary>
    /// <param name="text">分割するテキスト。</param>
    /// <param name="parseSize">分割する文字数。</param>
    /// <returns>N-gram 分割したコレクション。分割する文字数に満たないテキストのときは、残りの配列を <c>\0</c> で埋めます。データが存在しないときは空のコレクションを返却します。</returns>
    public static IEnumerable<char[]> ParseToCharArray(string text, Size parseSize = Size.Tri)
    {
        var words = new List<char[]>();
        int size = (int)parseSize;
        
        if (string.IsNullOrEmpty(text))
        {
            return words;
        }

        if (text.Length <= size)
        {
            var dest = new char[size];

            // 配列の大きさは固定にする（テキストが満たない長さの場合でも）
            Array.Copy(text.ToCharArray(), 0, dest, 0, text.Length);
            words.Add(dest);

            return words;
        }

        for (int i = 0; i < text.Length - size + 1; i++)
        {
            var dest = new char[size];

            text.CopyTo(i, dest, 0, size);
            words.Add(dest);
        }

        return words;
    }

    /// <summary>
    /// 指定したテキストを N-gram 分割し、<see cref="string"/> 型のコレクションを取得します。
    /// <para>
    /// <c>\0</c> の文字を含んだテキストはただしく処理できません。
    /// </para>
    /// </summary>
    /// <param name="text">分割するテキスト。</param>
    /// <param name="parseSize">分割する文字数。</param>
    /// <returns>N-gram 分割したコレクション。データが存在しないときは空のコレクションを返却します。</returns>
    public static IEnumerable<string> ParseToString(string text, Size parseSize = Size.Tri)
    {
        var chars = ParseToCharArray(text, parseSize);
        
        return chars.Select(p => new string(p).Trim('\0'));
    }
}
