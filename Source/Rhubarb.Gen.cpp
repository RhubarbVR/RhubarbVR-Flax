// This code was auto-generated. Do not modify it.

#include "Engine/Scripting/BinaryModule.h"
#include "Rhubarb.Gen.h"

StaticallyLinkedBinaryModuleInitializer StaticallyLinkedBinaryModuleRhubarb(GetBinaryModuleRhubarb);

extern "C" BinaryModule* GetBinaryModuleRhubarb()
{
    static NativeBinaryModule module("Rhubarb", MAssemblyOptions());
    return &module;
}
