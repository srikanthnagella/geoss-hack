from django.shortcuts import render
from .models import ImageTile, Score, ImageFile
from .serializers import ImageTileSerializer,ScoreSerializer,ImageFileSerializer
from rest_framework.response import Response
from rest_framework.decorators import api_view
from rest_framework import generics
from PIL import Image
from django.http import HttpResponse
import random

# Create your views here.
class ImageTileList(generics.ListCreateAPIView):
    queryset = ImageTile.objects.all()
    serializer_class = ImageTileSerializer    

class ScoreList(generics.ListCreateAPIView):
    queryset = Score.objects.all()
    serializer_class = ScoreSerializer

class ImageFileList(generics.ListCreateAPIView):
    queryset = ImageFile.objects.all()
    serializer_class = ImageFileSerializer

@api_view(['GET',])
def getRandomTile(request):
    """
    List all code snippets, or create a new snippet.
    """
    if request.method == 'GET':
        imageTiles = ImageTile.objects.get(pk=random.randrange(1, ImageTile.objects.all().count() + 1))
        serializer = ImageTileSerializer(imageTiles)
        return Response(serializer.data)

@api_view(['GET',])
def getImage(request,pk):
    """
    List all code snippets, or create a new snippet.
    """
    if request.method == 'GET':
        imageTiles = ImageTile.objects.get(pk=pk)
        print(imageTiles.fileid)
        imgFile = imageTiles.fileid
        img = Image.open(imgFile.filename)
        response = HttpResponse(content_type="image/jpg")
        img.save(response,'JPEG')
        return response

@api_view(['GET',])
def getImageScore(request,pk):
    """
    List all code snippets, or create a new snippet.
    """
    if request.method == 'GET':
        imageTiles = ImageTile.objects.get(pk=pk)
        serializer = ScoreSerializer(imageTiles.userScore)
        return Response(serializer.data)

