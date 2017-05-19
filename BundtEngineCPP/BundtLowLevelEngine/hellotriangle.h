#pragma once

#define GLFW_INCLUDE_VULKAN
#include <GLFW/glfw3.h>

#define GLM_FORCE_RADIANS
#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>

#include <algorithm>
#include <array>
#include <chrono>
#include <fstream>
#include <functional>
#include <iostream>
#include <set>
#include <stdexcept>
#include <string>
#include <vector>

#include "mystructs.h"
#include "vulkanquery.h"

class HelloTriangleApplication
{
public:
	__declspec(dllexport) void run();
	__declspec(dllexport) void run(GameObject gameObject);
	void createSwapChain();
	void recreateSwapChain();
private:
	void runForReal();

	GLFWwindow* window;
	VkInstance instance;
	VkDevice device;
	VkDebugReportCallbackEXT callback;
	VkSurfaceKHR surface;
	VkSwapchainKHR swapChain;
	VkPhysicalDevice physicalDevice = VK_NULL_HANDLE;
	VkQueue graphicsQueue;
	VkQueue presentQueue;
	std::vector<VkImage> swapChainImages;
	std::vector<VkImageView> swapChainImageViews;
	VkFormat swapChainImageFormat;
	VkExtent2D swapChainExtent;
	VkRenderPass renderPass;
	VkDescriptorSetLayout descriptorSetLayout;
	VkPipelineLayout pipelineLayout;
	VkPipeline graphicsPipeline;
	std::vector<VkFramebuffer> swapChainFramebuffers;
	VkCommandPool commandPool;
	VkCommandPool tempCommandPool;
	std::vector<VkCommandBuffer> commandBuffers;
	VkSemaphore imageAvailableSemaphore;
	VkSemaphore renderFinishedSemaphore;
	VkBuffer vertexBuffer;
	VkDeviceMemory vertexBufferMemory;
	VkBuffer indexBuffer;
	VkDeviceMemory indexBufferMemory;
	VkBuffer uniformBuffer;
	VkDeviceMemory uniformBufferMemory;
	VkDescriptorPool descriptorPool;
	VkDescriptorSet descriptorSet;
	VkImage textureImage;
	VkDeviceMemory textureImageMemory;
	VkImageView textureImageView;
	VkSampler textureSampler;

	std::vector<Vertex> squareVertices;
	std::vector<uint16_t> squareIndices;

	SwapChainSupportDetails querySwapChainSupport(VkPhysicalDevice device);
	void initWindow();
	void initVulkan();
	void createInstance();
	void setupDebugCallback();
	void createSurface();
	void pickPhysicalDevice();
	bool deviceIsSuitable(VkPhysicalDevice device);
	QueueFamilyIndices findQueueFamilies(VkPhysicalDevice device);
	void createLogicalDevice();
	VkExtent2D chooseSwapExtent(const VkSurfaceCapabilitiesKHR & capabilities);
	void createImageViews();
	void createRenderPass();
	void createDescriptorSetLayout();
	void createGraphicsPipeline();
	void createShaderModule(const std::vector<char>& code, VkShaderModule & shaderModule);
	void createFramebuffers();
	void createCommandPool();
	void createTempCommandPool();
	void createTextureImage();
	void createImage(uint32_t width, uint32_t height, VkFormat format, VkImageTiling tiling, VkImageUsageFlags usage, VkMemoryPropertyFlags properties, VkImage & image, VkDeviceMemory & imageMemory);
	VkCommandBuffer beginSingleTimeCommands();
	void endSingleTimeCommands(VkCommandBuffer commandBuffer);
	void transitionImageLayout(VkImage image, VkFormat format, VkImageLayout oldLayout, VkImageLayout newLayout);
	void copyBufferToImage(VkBuffer buffer, VkImage image, uint32_t width, uint32_t height);
	void createVertexBuffer();
	void createIndexBuffer();
	void createUniformBuffer();
	void createDescriptorPool();
	void createDescriptorSet();
	void createBuffer(VkDeviceSize size, VkBufferUsageFlags usage, VkMemoryPropertyFlags properties, VkBuffer & buffer, VkDeviceMemory & bufferMemory);
	void copyBuffer(VkBuffer srcBuffer, VkBuffer dstBuffer, VkDeviceSize size);
	uint32_t findMemoryType(uint32_t typeFilter, VkMemoryPropertyFlags properties);
	void createCommandBuffers();
	void createSemaphores();
	void mainLoop();
	void updateUniformBuffer();
	void copyToBufferMemory(const void * pointerToSource, VkDeviceMemory destinationBufferMemory, VkDeviceSize offset, VkDeviceSize size, VkMemoryMapFlags mapFlags);
	void drawFrame();
	void cleanup();
	void cleanupSwapChain();
	void createTextureImageView();
	void createImageView(VkImage image, VkFormat format, VkImageView * imageView);
	void createTextureSampler();
};
