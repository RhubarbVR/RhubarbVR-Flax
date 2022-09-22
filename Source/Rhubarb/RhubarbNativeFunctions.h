
#pragma once

#include "Engine/Scripting/Script.h"
#include "Engine/Core/Math/Vector4.h"

/// <summary>
/// RhubarbNativeFunctions Function Library
/// </summary>
API_CLASS(Static) class RHUBARB_API RhubarbNativeFunctions 
{
    DECLARE_SCRIPTING_TYPE_MINIMAL(RhubarbNativeFunctions);
public:

    /// <summary>
    /// Logs the function parameter natively.
    /// </summary>
    /// <param name="data">Data to pass to native code</param>
    API_FUNCTION() static void RunNativeAction(Vector4 data);
};
