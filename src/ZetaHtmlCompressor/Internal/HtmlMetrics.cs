namespace ZetaHtmlCompressor.Internal
{
	public sealed class HtmlMetrics
	{
		private int filesize = 0;
		private int emptyChars = 0;
		private int inlineScriptSize = 0;
		private int inlineStyleSize = 0;
		private int inlineEventSize = 0;

        /**
		 * Returns total filesize of a document
		 * 
		 * @return total filesize of a document, in bytes
		 */

        public int getFilesize() => filesize;

        /**
		 * @param filesize the filesize to set
		 */

        public void setFilesize(int filesize)
		{
			this.filesize = filesize;
		}

        /**
		 * Returns number of empty characters (spaces, tabs, end of lines) in a document
		 * 
		 * @return number of empty characters in a document
		 */

        public int getEmptyChars() => emptyChars;

        /**
		 * @param emptyChars the emptyChars to set
		 */

        public void setEmptyChars(int emptyChars)
		{
			this.emptyChars = emptyChars;
		}

        /**
		 * Returns total size of inline <code>&lt;script></code> tags
		 * 
		 * @return total size of inline <code>&lt;script></code> tags, in bytes
		 */

        public int getInlineScriptSize() => inlineScriptSize;

        /**
		 * @param inlineScriptSize the inlineScriptSize to set
		 */

        public void setInlineScriptSize(int inlineScriptSize)
		{
			this.inlineScriptSize = inlineScriptSize;
		}

        /**
		 * Returns total size of inline <code>&lt;style></code> tags
		 * 
		 * @return total size of inline <code>&lt;style></code> tags, in bytes
		 */

        public int getInlineStyleSize() => inlineStyleSize;

        /**
		 * @param inlineStyleSize the inlineStyleSize to set
		 */

        public void setInlineStyleSize(int inlineStyleSize)
		{
			this.inlineStyleSize = inlineStyleSize;
		}

        /**
		 * Returns total size of inline event handlers (<code>onclick</code>, etc)
		 * 
		 * @return total size of inline event handlers, in bytes
		 */

        public int getInlineEventSize() => inlineEventSize;

        /**
		 * @param inlineEventSize the inlineEventSize to set
		 */

        public void setInlineEventSize(int inlineEventSize)
		{
			this.inlineEventSize = inlineEventSize;
		}

        public override string ToString() => 
            $@"Filesize={filesize}, Empty Chars={emptyChars}, Script Size={inlineScriptSize}, Style Size={inlineStyleSize}, Event Handler Size={inlineEventSize}";
    }
}