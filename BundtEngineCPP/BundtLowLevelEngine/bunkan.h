#pragma once

#include "hellotriangle.h"

#include <stdexcept>
#include <iostream>

extern "C" __declspec(dllexport) int __cdecl start(
	Vector3* vertices,
	uint32_t verticesCount,
	uint16_t* indices,
	uint32_t indicesCount,
	Vector3* colors,
	Vector2* texCoords);

extern "C" __declspec(dllexport) int __cdecl start2();
