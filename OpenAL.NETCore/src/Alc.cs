using System;
using System.Reflection;
using System.Runtime.InteropServices;

// ReSharper disable UnusedMember.Global

// ReSharper disable once CheckNamespace
namespace OpenAL
{
    public class Alc
    {
        #region Dll Import Handling
        
        public const string OpenAlDll = "OpenAL";

        static Alc()
        {
            NativeLibrary.SetDllImportResolver(typeof(Al).Assembly, ImportResolver);
        }

        private static IntPtr ImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            IntPtr libHandle = IntPtr.Zero;
            if (libraryName == OpenAlDll)
            {
                if (System.Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    const string osx = "OpenAL.framework/OpenAL";
                    const string linux = "libopenal.so.1";
                    NativeLibrary.TryLoad(osx, assembly, DllImportSearchPath.System32, out libHandle);
                    if(libHandle == IntPtr.Zero) //If OSX path didn't work
                        NativeLibrary.TryLoad(linux, assembly, DllImportSearchPath.System32, out libHandle);
                }
                else
                {
                    const string windows = "openal32.dll";
                    NativeLibrary.TryLoad(windows, assembly, DllImportSearchPath.System32, out libHandle);
                }
            }

            return libHandle;
        }
        
        #endregion

        #region Enum

        public const int False = 0;
        public const int True = 1;
        public const int Frequency = 0x1007;
        public const int Refresh = 0x1008;
        public const int Sync = 0x1009;
        public const int MonoSources = 0x1010;
        public const int StereoSources = 0x1011;
        public const int NoError = False;
        public const int InvalidDevice = 0xA001;
        public const int InvalidContext = 0xA002;
        public const int InvalidEnum = 0xA003;
        public const int InvalidValue = 0xA004;
        public const int OutOfMemory = 0xA005;
        public const int DefaultDeviceSpecifier = 0x1004;
        public const int DeviceSpecifier = 0x1005;
        public const int Extensions = 0x1006;
        public const int MajorVersion = 0x1000;
        public const int MinorVersion = 0x1001;
        public const int AttributesSize = 0x1002;
        public const int AllAttributes = 0x1003;
        public const int DefaultAllDevicesSpecifier = 0x1012;
        public const int AllDevicesSpecifier = 0x1013;
        public const int CaptureDeviceSpecifier = 0x310;
        public const int CaptureDefaultDeviceSpecifier = 0x311;
        public const int EnumCaptureSamples = 0x312;

        #endregion

        #region Context Management Functions

        [DllImport(OpenAlDll, EntryPoint = "alcCreateContext")]
        private static extern IntPtr _CreateContext(IntPtr device, IntPtr attrlist);

        public static IntPtr CreateContext(IntPtr device, int[] attrList)
        {
            unsafe
            {
                fixed(int* arrayPtr = attrList)
                {
                    return _CreateContext(device, new IntPtr(arrayPtr));
                }
            }
        }

        [DllImport(OpenAlDll, EntryPoint = "alcMakeContextCurrent")]
        public static extern bool MakeContextCurrent(IntPtr context);

        [DllImport(OpenAlDll, EntryPoint = "alcProcessContext")]
        public static extern void ProcessContext(IntPtr context);

        [DllImport(OpenAlDll, EntryPoint = "alcSuspendContext")]
        public static extern void SuspendContext(IntPtr context);

        [DllImport(OpenAlDll, EntryPoint = "alcDestroyContext")]
        public static extern void DestroyContext(IntPtr context);

        [DllImport(OpenAlDll, EntryPoint = "alcGetCurrentContext")]
        public static extern IntPtr GetCurrentContext();

        [DllImport(OpenAlDll, EntryPoint = "alcGetContextsDevice")]
        public static extern IntPtr GetContextsDevice(IntPtr context);

        [DllImport(OpenAlDll, EntryPoint = "alcOpenDevice")]
        public static extern IntPtr OpenDevice(string deviceName);

        [DllImport(OpenAlDll, EntryPoint = "alcCloseDevice")]
        public static extern bool CloseDevice(IntPtr device);

        [DllImport(OpenAlDll, EntryPoint = "alcGetError")]
        public static extern int GetError(IntPtr device);

        [DllImport(OpenAlDll, EntryPoint = "alcIsExtensionPresent")]
        public static extern bool IsExtensionPresent(IntPtr device, string extname);

        [DllImport(OpenAlDll, EntryPoint = "alcGetProcAddress")]
        public static extern IntPtr GetProcAddress(IntPtr device, string funcname);

        [DllImport(OpenAlDll, EntryPoint = "alcGetEnumValue")]
        public static extern int GetEnumValue(IntPtr device, string enumname);

        #endregion

        #region Query Functions

        [DllImport(OpenAlDll, EntryPoint = "alcGetString")]
        private static extern IntPtr _GetString(IntPtr device, int param);

        public static string GetString(IntPtr device, int param) => Marshal.PtrToStringAnsi(_GetString(device, param));
        
        [DllImport(OpenAlDll, EntryPoint = "alcGetIntegerv")]
        public static extern void GetIntegerv(IntPtr device, int param, int size, IntPtr data);

        #endregion

        #region Capture Functions

        [DllImport(OpenAlDll, EntryPoint = "alcCaptureOpenDevice")]
        public static extern IntPtr CaptureOpenDevice(string devicename, uint frequency, int format, int buffersize);
        
        [DllImport(OpenAlDll, EntryPoint = "alcCaptureCloseDevice")]
        public static extern bool CaptureCloseDevice(IntPtr device);
        
        [DllImport(OpenAlDll, EntryPoint = "alcCaptureStart")]
        public static extern void CaptureStart(IntPtr device);
        
        [DllImport(OpenAlDll, EntryPoint = "alcCaptureStop")]
        public static extern void CaptureStop(IntPtr device);
        
        [DllImport(OpenAlDll, EntryPoint = "alcCaptureSamples")]
        public static extern unsafe void CaptureSamples(IntPtr device, void* buffer, int samples);

        #endregion
    }
}