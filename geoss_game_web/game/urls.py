from django.conf.urls import url, include
from . import views

urlpatterns = [
    url(r'^api-auth/', include('rest_framework.urls')),
    url(r'^ImageTile/$', views.ImageTileList.as_view()),
    url(r'^Score/$', views.ScoreList.as_view()), 
    url(r'^ImageFile/$', views.ImageFileList.as_view()), 
    url(r'randomTile/$', views.getRandomTile), 
    url(r'getImage/(?P<pk>[0-9]+)/$', views.getImage),
   url(r'getScore/(?P<pk>[0-9]+)/$', views.getImageScore),   

]