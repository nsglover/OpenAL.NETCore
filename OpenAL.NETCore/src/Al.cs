using System;
using System.Runtime.InteropServices;

// ReSharper disable UnusedMember.Global

// ReSharper disable once CheckNamespace
namespace OpenAL
{
    public class Al
    {
#if MACOS
        public const string OpenAlDll = "/System/Library/Frameworks/OpenAL.framework/OpenAL";
#elif LINUX
        public const string OpenAlDll = "libopenal.so.1";
#elif WINDOWS
        public const string OpenAlDll = "openal32.dll";
#endif

        #region Enum

        public const int None = 0;
        public const int False = 0;
        public const int True = 1;
        public const int SourceRelative = 0x202;
        public const int ConeInnerAngle = 0x1001;
        public const int ConeOuterAngle = 0x1002;
        public const int Pitch = 0x1003;
        public const int Position = 0x1004;
        public const int Direction = 0x1005;
        public const int Velocity = 0x1006;
        public const int Looping = 0x1007;
        public const int Buffer = 0x1009;
        public const int Gain = 0x100A;
        public const int MinGain = 0x100D;
        public const int MaxGain = 0x100E;
        public const int Orientation = 0x100F;
        public const int SourceState = 0x1010;
        public const int Initial = 0x1011;
        public const int Playing = 0x1012;
        public const int Paused = 0x1013;
        public const int Stopped = 0x1014;
        public const int BuffersQueued = 0x1015;
        public const int BuffersProcessed = 0x1016;
        public const int SecOffset = 0x1024;
        public const int SampleOffset = 0x1025;
        public const int ByteOffset = 0x1026;
        public const int SourceType = 0x1027;
        public const int Static = 0x1028;
        public const int Streaming = 0x1029;
        public const int Undetermined = 0x1030;
        public const int FormatMono8 = 0x1100;
        public const int FormatMono16 = 0x1101;
        public const int FormatStereo8 = 0x1102;
        public const int FormatStereo16 = 0x1103;
        public const int ReferenceDistance = 0x1020;
        public const int RolloffFactor = 0x1021;
        public const int ConeOuterGain = 0x1022;
        public const int MaxDistance = 0x1023;
        public const int Frequency = 0x2001;
        public const int Bits = 0x2002;
        public const int Channels = 0x2003;
        public const int Size = 0x2004;
        public const int Unused = 0x2010;
        public const int Pending = 0x2011;
        public const int Processed = 0x2012;
        public const int NoError = False;
        public const int InvalidName = 0xA001;
        public const int InvalidEnum = 0xA002;
        public const int InvalidValue = 0xA003;
        public const int InvalidOperation = 0xA004;
        public const int OutOfMemory = 0xA005;
        public const int Vendor = 0xB001;
        public const int Version = 0xB002;
        public const int Renderer = 0xB003;
        public const int Extensions = 0xB004;
        public const int EnumDopplerFactor = 0xC000;
        public const int EnumDopplerVelocity = 0xC001;
        public const int EnumSpeedOfSound = 0xC003;
        public const int EnumDistanceModel = 0xD000;
        public const int InverseDistance = 0xD001;
        public const int InverseDistanceClamped = 0xD002;
        public const int LinearDistance = 0xD003;
        public const int LinearDistanceClamped = 0xD004;
        public const int ExponentDistance = 0xD005;
        public const int ExponentDistanceClamped = 0xD006;

        #endregion
        
        #region Functions

        [DllImport(OpenAlDll, EntryPoint = "alEnable")]
        public static extern void Enable(int capability);

        [DllImport(OpenAlDll, EntryPoint = "alDisable")]
        public static extern void Disable(int capability);

        [DllImport(OpenAlDll, EntryPoint = "alIsEnabled")]
        public static extern bool IsEnabled(int capability);

        [DllImport(OpenAlDll, EntryPoint = "alGetString")]
        private static extern IntPtr _GetString(int param);

        public static string GetString(int param) => Marshal.PtrToStringAnsi(_GetString(param));

        [DllImport(OpenAlDll, EntryPoint = "alGetBooleanv")]
        public static extern void GetBooleanv(int param, out bool data);

        [DllImport(OpenAlDll, EntryPoint = "alGetIntegerv")]
        public static extern void GetIntegerv(int param, out int data);

        [DllImport(OpenAlDll, EntryPoint = "alGetFloatv")]
        public static extern void GetFloatv(int param, out float data);

        [DllImport(OpenAlDll, EntryPoint = "alGetDoublev")]
        public static extern void GetDoublev(int param, out double data);

        [DllImport(OpenAlDll, EntryPoint = "alGetBoolean")]
        public static extern bool GetBoolean(int param);

        [DllImport(OpenAlDll, EntryPoint = "alGetInteger")]
        public static extern int GetInteger(int param);

        [DllImport(OpenAlDll, EntryPoint = "alGetFloat")]
        public static extern float GetFloat(int param);

        [DllImport(OpenAlDll, EntryPoint = "alGetDouble")]
        public static extern double GetDouble(int param);

        [DllImport(OpenAlDll, EntryPoint = "alGetError")]
        public static extern int GetError();

        [DllImport(OpenAlDll, EntryPoint = "alIsExtensionPresent")]
        public static extern bool IsExtensionPresent(string extname);

        [DllImport(OpenAlDll, EntryPoint = "alGetProcAddress")]
        public static extern unsafe void* GetProcAddress(string fname);

        [DllImport(OpenAlDll, EntryPoint = "alGetEnumValue")]
        public static extern int GetEnumValue(string ename);

        [DllImport(OpenAlDll, EntryPoint = "alListenerf")]
        public static extern void Listenerf(int param, float value);

        [DllImport(OpenAlDll, EntryPoint = "alListener3f")]
        public static extern void Listener3f(int param, float value1, float value2, float value3);

        [DllImport(OpenAlDll, EntryPoint = "alListenerfv")]
        public static extern void Listenerfv(int param, float[] values);

        [DllImport(OpenAlDll, EntryPoint = "alGetListenerf")]
        public static extern void GetListenerf(int param, out float value);

        [DllImport(OpenAlDll, EntryPoint = "alGetListener3f")]
        public static extern void GetListener3f(int param, out float value1, out float value2, out float value3);

        [DllImport(OpenAlDll, EntryPoint = "alGetListenerfv")]
        private static extern unsafe void _GetListenerfv(int param, float* values);

        public static void GetListenerfv(int param, out float[] values)
        {
            unsafe
            {
                int len;
                switch(param)
                {
                    case Gain:
                        len = 1;
                        break;
                    case Position:
                    case Velocity:
                        len = 3;
                        break;
                    case Orientation:
                        len = 6;
                        break;
                    default:
                        len = 0;
                        break;
                }

                values = new float[len];

                fixed(float* arrayPtr = values)
                {
                    _GetListenerfv(param, arrayPtr);
                }
            }
        }

        [DllImport(OpenAlDll, EntryPoint = "alGenSources")]
        private static extern unsafe void _GenSources(int n, uint* sources);

        public static void GenSources(int n, out uint[] sources)
        {
            unsafe
            {
                sources = new uint[n];

                fixed(uint* arrayPtr = sources)
                {
                    _GenSources(n, arrayPtr);
                }
            }
        }

        public static void GenSource(out uint source)
        {
            GenSources(1, out var sources);
            source = sources[0];
        }

        [DllImport(OpenAlDll, EntryPoint = "alDeleteSources")]
        public static extern void DeleteSources(int n, uint[] sources);

        public static void DeleteSource(uint source) => DeleteSources(1, new[] {source});

        [DllImport(OpenAlDll, EntryPoint = "alIsSource")]
        public static extern bool IsSource(uint sid);

        [DllImport(OpenAlDll, EntryPoint = "alSourcef")]
        public static extern void Sourcef(uint sid, int param, float value);

        [DllImport(OpenAlDll, EntryPoint = "alSource3f")]
        public static extern void Source3f(uint sid, int param, float value1, float value2, float value3);

        [DllImport(OpenAlDll, EntryPoint = "alSourcefv")]
        public static extern void Sourcefv(uint sid, int param, float[] values);

        [DllImport(OpenAlDll, EntryPoint = "alSourcei")]
        public static extern void Sourcei(uint sid, int param, int value);

        [DllImport(OpenAlDll, EntryPoint = "alSource3i")]
        public static extern void Source3i(uint sid, int param, int value1, int value2, int value3);

        [DllImport(OpenAlDll, EntryPoint = "alSourceiv")]
        public static extern void Sourceiv(uint sid, int param, int[] values);

        [DllImport(OpenAlDll, EntryPoint = "alGetSourcef")]
        public static extern void GetSourcef(uint sid, int param, out float value);

        [DllImport(OpenAlDll, EntryPoint = "alGetSource3f")]
        public static extern void GetSource3f(uint sid, int param, out float value1, out float value2, out float value3);

        [DllImport(OpenAlDll, EntryPoint = "alGetSourcefv")]
        private static extern unsafe void _GetSourcefv(uint sid, int param, float* values);

        public static void GetSourcefv(uint sid, int param, out float[] values)
        {
            unsafe
            {
                int len;
                switch(param)
                {
                    case Pitch:
                    case Gain:
                    case MaxDistance:
                    case RolloffFactor:
                    case ReferenceDistance:
                    case MinGain:
                    case MaxGain:
                    case ConeOuterGain:
                    case ConeInnerAngle:
                    case ConeOuterAngle:
                    case SecOffset:
                    case SampleOffset:
                    case ByteOffset:
                        len = 1;
                        break;
                    case Position:
                    case Velocity:
                    case Direction:
                        len = 3;
                        break;
                    default:
                        len = 0;
                        break;
                }

                values = new float[len];

                fixed(float* arrayPtr = values)
                {
                    _GetSourcefv(sid, param, arrayPtr);
                }
            }
        }

        [DllImport(OpenAlDll, EntryPoint = "alGetSourcei")]
        public static extern void GetSourcei(uint sid, int param, out int value);

        [DllImport(OpenAlDll, EntryPoint = "alGetSource3i")]
        public static extern void GetSource3i(uint sid, int param, out int value1, out int value2, out int value3);

        [DllImport(OpenAlDll, EntryPoint = "alGetSourceiv")]
        private static extern unsafe void _GetSourceiv(uint sid, int param, int* values);

        public static void GetSourceiv(uint sid, int param, out int[] values)
        {
            unsafe
            {
                int len;
                switch(param)
                {
                    case MaxDistance:
                    case RolloffFactor:
                    case ReferenceDistance:
                    case ConeInnerAngle:
                    case ConeOuterAngle:
                    case SourceRelative:
                    case SourceType:
                    case Looping:
                    case Buffer:
                    case SourceState:
                    case BuffersQueued:
                    case BuffersProcessed:
                    case SecOffset:
                    case SampleOffset:
                    case ByteOffset:
                        len = 1;
                        break;
                    case Direction:
                        len = 3;
                        break;
                    default:
                        len = 0;
                        break;
                }
                
                values = new int[len];

                fixed(int* arrayPtr = values)
                {
                    _GetSourceiv(sid, param, arrayPtr);
                }
            }
        }

        [DllImport(OpenAlDll, EntryPoint = "alSourcePlayv")]
        public static extern void SourcePlayv(int ns, uint[] sids);

        [DllImport(OpenAlDll, EntryPoint = "alSourceStopv")]
        public static extern void SourceStopv(int ns, uint[] sids);

        [DllImport(OpenAlDll, EntryPoint = "alSourceRewindv")]
        public static extern void SourceRewindv(int ns, uint[] sids);

        [DllImport(OpenAlDll, EntryPoint = "alSourcePausev")]
        public static extern void SourcePausev(int ns, uint[] sids);

        [DllImport(OpenAlDll, EntryPoint = "alSourcePlay")]
        public static extern void SourcePlay(uint sid);

        [DllImport(OpenAlDll, EntryPoint = "alSourceStop")]
        public static extern void SourceStop(uint sid);

        [DllImport(OpenAlDll, EntryPoint = "alSourceRewind")]
        public static extern void SourceRewind(uint sid);

        [DllImport(OpenAlDll, EntryPoint = "alSourcePause")]
        public static extern void SourcePause(uint sid);

        [DllImport(OpenAlDll, EntryPoint = "alSourceQueueBuffers")]
        public static extern void SourceQueueBuffers(uint sid, int numEntries, uint[] bids);

        [DllImport(OpenAlDll, EntryPoint = "alSourceUnqueueBuffers")]
        public static extern void SourceUnqueueBuffers(uint sid, int numEntries, uint[] bids);

        [DllImport(OpenAlDll, EntryPoint = "alGenBuffers")]
        private static extern unsafe void _GenBuffers(int n, uint* buffers);

        public static void GenBuffers(int n, out uint[] buffers)
        {
            unsafe
            {
                buffers = new uint[n];

                fixed(uint* arrayPtr = buffers)
                {
                    _GenSources(n, arrayPtr);
                }
            }
        }

        public static void GenBuffer(out uint buffer)
        {
            GenBuffers(1, out var buffers);
            buffer = buffers[0];
        }

        [DllImport(OpenAlDll, EntryPoint = "alDeleteBuffers")]
        public static extern void DeleteBuffers(int n, uint[] buffers);

        public static void DeleteBuffer(uint buffer) => DeleteBuffers(1, new[] {buffer});

        [DllImport(OpenAlDll, EntryPoint = "alIsBuffer")]
        public static extern bool IsBuffer(uint bid);

        [DllImport(OpenAlDll, EntryPoint = "alBufferData")]
        private static extern void _BufferData(uint bid, int format, IntPtr data, int size, int freq);

        public static void BufferData(uint bid, int format, byte[] data, int size, int freq)
        {
            unsafe
            {
                fixed(byte* arrayPtr = data)
                {
                    _BufferData(bid, format, new IntPtr(arrayPtr), size, freq);
                }
            }
        }

        [DllImport(OpenAlDll, EntryPoint = "alBufferi")]
        public static extern void Bufferi(uint bid, int param, int value);

        [DllImport(OpenAlDll, EntryPoint = "alGetBufferi")]
        public static extern void GetBufferi(uint bid, int param, out int value);

        [DllImport(OpenAlDll, EntryPoint = "alDopplerFactor")]
        public static extern void DopplerFactor(float value);

        [DllImport(OpenAlDll, EntryPoint = "alDopplerVelocity")]
        public static extern void DopplerVelocity(float value);

        [DllImport(OpenAlDll, EntryPoint = "alSpeedOfSound")]
        public static extern void SpeedOfSound(float value);

        [DllImport(OpenAlDll, EntryPoint = "alDistanceModel")]
        public static extern void DistanceModel(int distanceModel);
        
        #endregion
    }
}