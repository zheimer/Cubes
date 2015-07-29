using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Application
{
    class PathConversion
    {

        public static String ToAbsolutePath(String basePath, String path)
        {
            if (String.IsNullOrEmpty(path))
                return null;
            if (String.IsNullOrEmpty(basePath))
                return path;

            Uri path2 = new Uri(path, UriKind.RelativeOrAbsolute);
            if (path2.IsAbsoluteUri)
                return path;
            Uri basePath2 = new Uri(basePath + "/", UriKind.Absolute);
            Uri absPath = new Uri(basePath2, path);
            return absPath.LocalPath;
        }

        public static String ToRelativePath(String basePath, String path)
        {
            if (String.IsNullOrEmpty(path))
                return null;
            if (String.IsNullOrEmpty(basePath))
                return path;

            Uri uri1 = new Uri(path, UriKind.RelativeOrAbsolute);
            if (uri1.IsAbsoluteUri)
            {
                Uri uri2 = new Uri(basePath + "/", UriKind.Absolute);
                Uri relativeUri = uri2.MakeRelativeUri(uri1);
                return Uri.UnescapeDataString(relativeUri.ToString()).Replace('/', Path.DirectorySeparatorChar);
            }

            return path;
        }

    }
}
