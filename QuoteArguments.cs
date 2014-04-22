using System;
using System.Text;
using System.Collections;
 
public class QuoteArguments
{
	public static string Quote(IList args) {
		// adopted from python's subprocess.list2cmdline function
		StringBuilder sb = new System.Text.StringBuilder();
		foreach (string arg in args) {
			int backslashes = 0;

			// Add a space to separate this argument from the others
			if (sb.Length > 0) {
				sb.Append(" ");
			}

			bool needquote = arg.Length == 0 || arg.Contains(" ") || arg.Contains("\t");
			if (needquote) {
				sb.Append('"');
			}

			foreach (char c in arg) {
				if (c == '\\') {
					// Don't know if we need to double yet.
					backslashes++;
				}
				else if (c == '"') {
					// Double backslashes.
					sb.Append(new String('\\', backslashes*2));
					backslashes = 0;
					sb.Append("\\\"");
				} else {
					// Normal char
					if (backslashes > 0) {
						sb.Append(new String('\\', backslashes));
						backslashes = 0;
					}
					sb.Append(c);
				}
			}

			// Add remaining backslashes, if any.
			if (backslashes > 0) {
				sb.Append(new String('\\', backslashes));
			}

			if (needquote) {
				sb.Append(new String('\\', backslashes));
				sb.Append('"');
			}
		}
		return sb.ToString();
	}
}
