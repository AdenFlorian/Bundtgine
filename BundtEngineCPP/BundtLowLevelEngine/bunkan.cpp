#pragma once

#include "bunkan.h"
#include "mylogger.h"

#include <stdexcept>
#include <iostream>

int start(
	Vector3* vertices,
	uint32_t verticesCount,
	uint16_t* indices,
	uint32_t indicesCount,
	Vector3* colors,
	Vector2* texCoords)
{
	LogInfo("verticesCount: " + std::to_string(verticesCount));
	LogInfo("indicesCount: " + std::to_string(indicesCount));

	HelloTriangleApplication app;

	try
	{
		GameObject go = {};
		go.vertices = vertices;
		go.verticesCount = verticesCount;
		go.indices = indices;
		go.indicesCount = indicesCount;
		go.colors = colors;
		go.texCoords = texCoords;

		app.run(go);
	}
	catch (const std::runtime_error& e)
	{
		std::cerr << e.what() << std::endl;
		return EXIT_FAILURE;
	}

	return EXIT_SUCCESS;
}

int start2()
{
	HelloTriangleApplication app;

	try
	{
		app.run();
	}
	catch (const std::runtime_error& e)
	{
		std::cerr << e.what() << std::endl;
		return EXIT_FAILURE;
	}

	return EXIT_SUCCESS;
}
