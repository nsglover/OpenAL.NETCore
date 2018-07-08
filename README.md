# OpenAL.NETCore
OpenAL.NETCore is an up-to-date set of cross-platform C# bindings for OpenAL 1.1 targeting .NET Core.

Certain functions listed in the [OpenAL specification](https://www.openal.org/documentation/openal-1.1-specification.pdf) have been omitted because they have no actual use in the API. For example, for the "alBuffer3i(int, int, int, int)" function, there is no possible value for the first parameter that will not cause the function to throw the AL_INVALID_ENUM error.

This project was inspired by [OpenTK](https://github.com/opentk/opentk), particularly the [OpenTK.Audio](https://github.com/opentk/opentk/tree/develop/src/OpenTK/Audio) namespace.

# Installation

A NuGet package is on its way. For now, please install OpenAL.NETCore manually.

To install manually, clone this repository, build the assembly, and reference the resulting .dll from your project. Additionally, certain operating systems may require you to install OpenAL itself. See below.

## macOS

No additional installation is necessary since the OpenAL framework is packaged with the OS. If you get an error along the lines of "DllNotFoundException: "'/System/Library/Frameworks/OpenAL.framework/OpenAL' could not be found.", then you may be having some other problems with your system.

## Linux
Run the following in a terminal:

<code>
git clone git://repo.or.cz/openal-soft.git
</code>
<br/>
<code>
cd openal-soft
</code>
<br/>
<code>
cd build
</code>
<br/>
<code>
cmake ..
</code>
<br/>
<code>
make
</code>
<br/>
<code>
sudo make install
</code>
<br/>

Make sure libopenal.so.1 is in a familiar location (where your package manager typically puts things) and OpenAL.NETCore should find it. If it doesn't, try moving the file to the same directory as your project's executable.

## Windows

Please install [OpenAL](https://www.openal.org/downloads/) if you do not already have it on your system. It should install a binary named "openal32.dll", which OpenAL.NETCore should find on its own. If not, try moving the .dll to the same directory as your project's executable.
