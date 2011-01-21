This library is used to parse a WMV file container.  When I wrote this, the only real purpose was to grab the duration of the video, so not a whole lot else is built out.
The framework for getting more data is in place though.  Example usage:

WMVStream wmv = new WMVStream("C:\\Users\\Public\\Videos\\Sample Videos\\Wildlife.wmv");
UInt64 duration = wmv.GetDuration();
Console.Write(duration);

