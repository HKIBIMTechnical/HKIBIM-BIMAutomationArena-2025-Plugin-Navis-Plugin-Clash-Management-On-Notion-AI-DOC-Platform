# __author__ = 'Andy'
# -*- coding: utf-8 -*-


import sys


import os

import notion.block
import requests,json

Automation_Test_Token="your token" 
headers = {
    "accept": "application/json",
    "Authorization": "Bearer " + Automation_Test_Token,
    "Content-Type": "application/json",
    "Notion-Version": "2022-06-28"
}

class notionFun(object):
    headers=None
    def __init__(self, headers):
        self.headers=headers
        notionFun.headers=headers
        
    @staticmethod
    def append_rich_text_in_page(parent_id: str, text :str):
        url = f"https://api.notion.com/v1/blocks/{parent_id}/children"   
        text_block = {
            "type": "paragraph",
            "paragraph": {
            "rich_text": [{
                "type": "text",
                "text": {
                "content": text,
                }
            }]
            } 
        }        
        response = requests.request(
        "PATCH",
        url,
        headers=notionFun.headers,
        json={"children": [text_block]}
        ) 

        return response
    @staticmethod
    def get_all_children_block_ids(parent_id):
        ids=[]
        url=f"https://api.notion.com/v1/blocks/{parent_id}/children"
        response = requests.request(
        "GET",
        url,
        headers=notionFun.headers,
        ) 
        for object in response.json()["results"]:
            ids.append(object["id"])

        return ids
    @staticmethod
    def get_page_response_by_pageId(pageid):
        url=f"https://api.notion.com/v1/pages/{pageid}"
        response=requests.request(method="GET",url=url,headers=notionFun.headers)
        return response
    @staticmethod
    def get_all_children_block_object_dictionary_list(parent_id):
        blocks=[]
        url=f"https://api.notion.com/v1/blocks/{parent_id}/children"
        response = requests.request(
        "GET",
        url,
        headers=notionFun.headers,
        ) 
        for object in response.json()["results"]:
            blocks.append(object)

        return blocks
    @staticmethod
    def get_all_children_block_response(parent_id):
        url=f"https://api.notion.com/v1/blocks/{parent_id}/children"
        response = requests.request(
        "GET",
        url,
        headers=notionFun.headers,
        ) 

        return response
    @staticmethod
    def get_block_by_id(block_id):
        url=f"https://api.notion.com/v1/blocks/{block_id}"
        response = requests.request(
        "GET",
        url,
        headers=notionFun.headers,
        ) 
        return response
    @staticmethod
    def add_image_by_url_in_page(pageId,imageURL):
        url = f"https://api.notion.com/v1/blocks/{pageId}/children"   
        text_block = {
            "type": "image",
            "image": {
                "type": "external",
                "external": {
                    "url": imageURL
                }
            }
        }        
        response = requests.request(
        "PATCH",
        url,
        headers=notionFun.headers,
        json={"children": [text_block]}
        ) 

        return response
    @staticmethod
    def response_convert_to_json_with_indent_4(response):
        ret= json.dumps(response.json(),indent=4)
        return ret
    @staticmethod
    def dictionary_convert_to_json_with_indent_4(dict):
        ret= json.dumps(dict,indent=4)
        return ret

    @staticmethod
    def add_page_heading_date_image_in_database_with_icon_new(dataTableId,icon_url,VP_Name,VP_ID,Comments,Path,s_date,e_date,date,imageUrl):
        '''
        '''
        url="https://api.notion.com/v1/pages"
        data=\
        {
            "icon": 
                {
                    "type": "external",
                    "external": 
                        {
                            "url":icon_url
                        }                        
                },
            "parent": 
                {
                    "type": "database_id",
                    "database_id": dataTableId
                },
            "properties": 
                {
                    "VP_Name":
                        {
                            "title": 
                                [
                                    {
                                        "text": 
                                            {
                                                "content": VP_Name
                                            }
                                    }
                                ]
                        },
                    "VP_ID":
                        {
                            "select": 
                                {
                                    "name": VP_ID
                                }

                        },
                    "Comments":
                        {
                            "rich_text": 
                                [
                                    {
                                        "text": 
                                            {
                                                "content": Comments
                                            }
                                    }
                                ]
                        },
                    "Path":
                        {
                            "rich_text": 
                                [
                                    {
                                        "text": 
                                            {
                                                "content": Path
                                            }
                                    }
                                ]
                        },
                    "s_date":
                        {
                            "rich_text": 
                                [
                                    {
                                        "text": 
                                            {
                                                "content": s_date
                                            }
                                    }
                                ]
                        },
                    "e_date":
                        {
                            "rich_text": 
                                [
                                    {
                                        "text": 
                                            {
                                                "content": e_date
                                            }
                                    }
                                ]
                        },
                },        
            "children":
                [
                    {
                        "type":"paragraph",
                        "paragraph":
                            {
                                "rich_text":
                                    [
                                        {
                                            "type":"text",
                                            "text":
                                                {
                                                    "content":" "
                                                }
                                        }
                                    ],
                            }
                    },
                    {
                        "type":"paragraph",
                        "paragraph":
                            {
                                "rich_text":
                                    [
                                        {
                                            "type":"text",
                                            "text":
                                                {
                                                    "content":" "
                                                }
                                        }
                                    ],
                            }
                    },
                    {
                        "type":"paragraph",
                        "paragraph":
                            {
                                "rich_text":
                                    [
                                        {
                                            "type":"text",
                                            "text":
                                                {
                                                    "content":"+++++++++++++++++++++++++++++++++"
                                                }
                                        }
                                    ],
                            }
                    },
                    {
                        "type":"heading_2",
                        "heading_2":
                            {
                                "rich_text":
                                    [
                                        {
                                            "type":"text",
                                            "text":
                                                {
                                                    "content": str(date)
                                                }
                                        }
                                    ],
                                "is_toggleable": True,
                                
                                "children":
                                    [
                                        {
                                            
                                            "object": "block",
                                            "type": "embed",
                                            "embed": {
                                                    "url": imageUrl

                                            }

                                        }
                                    ]
                            }                            

                    }

                ]
        }
        response = requests.request(
        "POST",
        url,
        headers=notionFun.headers,
        json=data
        ) 
        return response

    @staticmethod
    def add_page_heading_date_in_database_with_icon_new(dataTableId,icon_url,VP_Name,VP_ID,Comments,Path,s_date,e_date,date):
        '''
        '''
        url="https://api.notion.com/v1/pages"
        data=\
        {
            "icon": 
                {
                    "type": "external",
                    "external": 
                        {
                            "url":icon_url
                        }                        
                },
            "parent": 
                {
                    "type": "database_id",
                    "database_id": dataTableId
                },
            "properties": 
                {
                    "VP_Name":
                        {
                            "title": 
                                [
                                    {
                                        "text": 
                                            {
                                                "content": VP_Name
                                            }
                                    }
                                ]
                        },
                    "VP_ID":
                        {
                            "select": 
                                {
                                    "name": VP_ID
                                }

                        },
                    "Comments":
                        {
                            "rich_text": 
                                [
                                    {
                                        "text": 
                                            {
                                                "content": Comments
                                            }
                                    }
                                ]
                        },
                    "Path":
                        {
                            "rich_text": 
                                [
                                    {
                                        "text": 
                                            {
                                                "content": Path
                                            }
                                    }
                                ]
                        },
                    "s_date":
                        {
                            "rich_text": 
                                [
                                    {
                                        "text": 
                                            {
                                                "content": s_date
                                            }
                                    }
                                ]
                        },
                    "e_date":
                        {
                            "rich_text": 
                                [
                                    {
                                        "text": 
                                            {
                                                "content": e_date
                                            }
                                    }
                                ]
                        },
                },        
            "children":
                [
                    {
                        "type":"paragraph",
                        "paragraph":
                            {
                                "rich_text":
                                    [
                                        {
                                            "type":"text",
                                            "text":
                                                {
                                                    "content":" "
                                                }
                                        }
                                    ],
                            }
                    },
                    {
                        "type":"paragraph",
                        "paragraph":
                            {
                                "rich_text":
                                    [
                                        {
                                            "type":"text",
                                            "text":
                                                {
                                                    "content":" "
                                                }
                                        }
                                    ],
                            }
                    },
                    {
                        "type":"paragraph",
                        "paragraph":
                            {
                                "rich_text":
                                    [
                                        {
                                            "type":"text",
                                            "text":
                                                {
                                                    "content":"+++++++++++++++++++++++++++++++++"
                                                }
                                        }
                                    ],
                            }
                    },

                ]
        }
        response = requests.request(
        "POST",
        url,
        headers=notionFun.headers,
        json=data
        ) 
        return response
    

    @staticmethod
    def add_heading_date_image_in_page_after_blockid(pageId,blockId,date,imageUrl):
        url=f"https://api.notion.com/v1/blocks/{pageId}/children"
        data=\
            {
                "after": blockId,

                "children":
                [
                
                    {
                        "type":"heading_2",
                        "heading_2":
                            {
                                "rich_text":
                                    [
                                        {
                                            "type":"text",
                                            "text":
                                                {
                                                    "content": str(date)
                                                }
                                        }
                                    ],
                                "is_toggleable": True,
                                
                                "children":
                                    [
                                        {
                                            "object": "block",
                                            "type": "embed",
                                            "embed": {
                                                    "url": imageUrl

                                            }

                                        }
                                    ]
                            }                            

                    }
                    
                ]
            }
        response = requests.request(
        "PATCH",
        url,
        headers=notionFun.headers,
        json=data
        ) 
        return response
    
    @staticmethod    
    def get_find_blockid_if_match_paragraph_rich_text_in_page_block_children(pageid,match_string="++++++++++++++++++++++"):
        block_children= notionFun.get_all_children_block_response(pageid)
        for i in block_children.json()["results"]:
            for k,v in i.items():
                if k=="paragraph":
                    try:
                        if match_string in v["rich_text"][0]["text"]["content"]:
                            return i["id"]
                    except:
                        pass
        return None
    @staticmethod
    def get_database_by_dataTableId(dataTableId):
        url=f"https://api.notion.com/v1/databases/{dataTableId}"
        response = requests.request(
        "GET",
        url,
        headers=notionFun.headers,
        ) 
        return response
    @staticmethod
    def get_query_first_page_id_by_query_select_property_by_dataTableId(dataTableId,propertyName="VP_ID",propertyValue="fffaaa"):
        url=f"https://api.notion.com/v1/databases/{dataTableId}/query"
        data=\
        {
            "filter": {
                "property": propertyName,
                "select": {
                "equals": propertyValue
                }
            }
        }
        res=requests.request("POST",url,headers=notionFun.headers,json=data)
        print(len(res.json()["results"]))
        if len(res.json()["results"])==0:
            return None
        else:
            return res.json()["results"][0]["id"]

    @staticmethod
    def response_to_json_file(response,json_file_path=r"test.json"):
        with open(json_file_path,'w',encoding='utf8') as f:
            json.dump(response.json(),f,ensure_ascii=False, indent=2)
    @staticmethod
    def update_page_property_select(pageId,selectPropertyName="VP_ID",property_String_Value="FFFAAA"):
        url=f"https://api.notion.com/v1/pages/{pageId}"
        data=\
            {
                "properties": 
                    {
                        selectPropertyName:
                            {
                                "select": 
                                    {
                                        "name": property_String_Value
                                    }

                            },
                    }
            }
        res=requests.request("PATCH",url,headers=notionFun.headers,json=data)
        return res
    @staticmethod
    def update_page_property_title_name(pageId,titlePropertyName="VP_Name", property_String_Value="ccc"):
        url=f"https://api.notion.com/v1/pages/{pageId}"
        data=\
            {
                "properties": 
                    {
                    titlePropertyName:
                        {
                            "title": 
                                [
                                    {
                                        "text": 
                                            {
                                                "content": property_String_Value
                                            }
                                    }
                                ]
                        },
                    }
            }
        res=requests.request("PATCH",url,headers=notionFun.headers,json=data)
        return res
    @staticmethod
    def update_page_property_richText(pageId,richTextPropertyName="Comments", property_String_Value="comments!!!!!"):
        url=f"https://api.notion.com/v1/pages/{pageId}"
        data=\
            {
                "properties": 
                    {
                    richTextPropertyName:
                        {
                            "rich_text": 
                                [
                                    {
                                        "text": 
                                            {
                                                "content": property_String_Value
                                            }
                                    }
                                ]
                        },
                    }
            }
        res=requests.request("PATCH",url,headers=notionFun.headers,json=data)
        return res
    @staticmethod
    def get_query_all_by_dataTableId(dataTableId):
        """
        max page size is 100
        """
        url=f"https://api.notion.com/v1/databases/{dataTableId}/query"

        res=requests.request("POST",url,headers=notionFun.headers)
        
        print(len(res.json()["results"]))
        if len(res.json()["results"])==0:
            return None
        else:
            return res.json()["results"][0]["id"]        
    @staticmethod
    def get_title_property_value(response,title_Name="VP_Name"):
        value=response.json()["properties"][title_Name]["title"][0]["text"]["content"]
        return value
    
        
#--------------------------------------------other function--------------------------------------------------------
import imgbbpy

def upload_Image_and_get_url(image_path, api_key="your api key"):
    client = imgbbpy.SyncClient(api_key)
    image = client.upload(file=image_path)
    print(image.url)
    return image.url  
import datetime
def current_date():
    current_time = datetime.datetime.now()
    date = str(current_time.year).zfill(4) + str(current_time.month).zfill(2) + str(current_time.day).zfill(2)
    return date

def deleteFile(filePath):
    if os.path.exists(filePath):
        os.remove(filePath)

#--------------------------------------------other function--------------------------------------------------------



#-------------------------------------------google drive------------------------------------------------------------

import os.path
from google.auth.transport.requests import Request
from google.oauth2.credentials import Credentials
from google_auth_oauthlib.flow import InstalledAppFlow
from googleapiclient.discovery import build
from googleapiclient.errors import HttpError
from googleapiclient.http import MediaFileUpload
from google.oauth2 import service_account



class MyGoogleDrive(object):
    def __init__(self,credentials_json_path,token_json_path) -> None:
        self.credentials_json_path=credentials_json_path
        self.token_json_path=token_json_path
        SCOPES = ["https://www.googleapis.com/auth/drive"]

        creds=None
        if os.path.exists(self.token_json_path):
            with open(self.token_json_path, "r") as json_file:
                data = json.load(json_file)
                expiry_date=self.add_date_after_current_now(1)
                expiry_date=expiry_date.strftime("%Y-%m-%dT%H:%M:%SZ")  
                data["expiry"]=expiry_date
            with open(self.token_json_path, "w") as token:
                json.dump(data,token,indent=4)   
                
            creds = Credentials.from_authorized_user_file(self.token_json_path, SCOPES)

        if not creds or not creds.valid:
            if creds and creds.expired and creds.refresh_token:
                creds.refresh(Request())
            else:
                flow = InstalledAppFlow.from_client_secrets_file(
                        self.credentials_json_path, SCOPES
                    )
                creds = flow.run_local_server(port=0)
                
            with open(self.token_json_path, "w") as token:
                token.write(creds.to_json())   
        self.service=build("drive","v3",credentials=creds)
    def __init__(self,service_account_file_path) -> None:
        SCOPES = ['https://www.googleapis.com/auth/drive']

        credentials = service_account.Credentials.from_service_account_file(
            service_account_file_path, scopes=SCOPES)
        self.service = build('drive', 'v3', credentials=credentials)           
    @staticmethod
    def add_date_after_current_now(add_date="3") -> datetime.datetime:
        '''
        add_date can be other integer, it will automatically calculate datatime 
        for example if add_date is 3 and current date is 2024-08-26 15:02:25.477234,
        then the result is 2024-08-29 15:02:25.477234
        '''
        a=datetime.datetime.now()+datetime.timedelta(add_date)
        return a  
    def list_files(self):
        '''
        return list, include name, id, webViewLink=url
        example [{"id":id, "name":name, "webViewLink":webViewLink}]
        '''
        results=self.service.files().list(fields="nextPageToken, files(id, name, webViewLink)").execute() # all file and folder list
        items = results.get("files", [])
        if not items:
            print("No files found.")
            return items 

        return items
    def query_file_or_folder(self,filename,folder_id):
        '''
        return list, include name, id, webViewLink=url
        example [{"id":id, "name":name, "webViewLink":webViewLink}]
        '''
        response=self.service.files().list(
            q=f"name='{filename}' and parents='{folder_id}'",
            spaces='drive',
            fields='nextPageToken, files(id, name,webViewLink)',
            pageToken=None).execute()
        if response==[]: 
            return response["files"]
        return response["files"]
        
    def get_url_by_Ids(self,ids):
        '''
        return list
        '''
        url=[]
        for id in ids:
            share_link=self.service.files().get(
                fileId=id,
                fields="webViewLink"
            ).execute()
            
            url.append(share_link["webViewLink"])

        return url
    
        
    def upload_or_update_file_return_id(self,filename,fileFullPath,folder_Id):
        media=MediaFileUpload(f"{fileFullPath}")
        queryFiles= self.query_file_or_folder(filename=filename,folder_id=folder_Id)
        if queryFiles==[]:
            file_metadata={
                "name":filename,
                "parents":[folder_Id]
            }
            
            file=self.service.files().create(body=file_metadata,media_body=media,fields="id").execute()
        
            return file.get("id")
        else:
            
            update_file=self.service.files().update(
                fileId=queryFiles[0]["id"],
                media_body=media,
            ).execute()
            return update_file.get("id")

    def upload_or_update_file_return_url(self,filename,fileFullPath,folder_Id):
        media=MediaFileUpload(f"{fileFullPath}")
        queryFiles= self.query_file_or_folder(filename=filename,folder_id=folder_Id)
        if queryFiles==[]:
            file_metadata={
                "name":filename,
                "parents":[folder_Id]
            }
            
            file=self.service.files().create(body=file_metadata,media_body=media,fields=("id")).execute()
            url=self.get_urls_by_Ids([file.get("id")])[0]
            return url
        else:
            
            update_file=self.service.files().update(
                fileId=queryFiles[0]["id"],
                media_body=media,
            ).execute()
            url=self.get_urls_by_Ids([update_file.get("id")])[0]            
            return url
         

#-------------------------------------------google drive-------------------------------------------------------------        


file = open(r"c:\export_temp\temp_python_input_parameter.txt",'r')
readstr=file.read()
splitstr=readstr.split("++++++++++++++")

p_vp_id=splitstr[0]
p_vp_name=splitstr[1]
p_comments=splitstr[2]
p_path=splitstr[3]
p_s_date=splitstr[4]
p_e_date=splitstr[5]
p_image_path=splitstr[6].replace("\n","")

notionFun=notionFun(headers=headers)

LOGO_URL="logo url"
pageid_Navis_VP_Table=splitstr[7].replace("\n","")

find_page_id=notionFun.get_query_first_page_id_by_query_select_property_by_dataTableId(pageid_Navis_VP_Table,"VP_ID",p_vp_id)
date=current_date()


token_json_path=r"token.json"
credentials_json_path=r"google_drive_credentials.json"
service_account_file=r"service_account_file.json"

folder_id = 'your folder id' 


if find_page_id==None:
    p_e_date=""
    notionFun.add_page_heading_date_in_database_with_icon_new(pageid_Navis_VP_Table,LOGO_URL,p_vp_name,p_vp_id,p_comments,p_path,p_s_date,p_e_date,date)
else:
    if "close" in  p_vp_name.lower():
        #++++++++++++++++++++++ 
        find_page_response=notionFun.get_page_response_by_pageId(find_page_id)
        currentTitle = notionFun.get_title_property_value(find_page_response,"VP_Name")
        if "close" not in str(currentTitle).lower() :
            blockid=notionFun.get_find_blockid_if_match_paragraph_rich_text_in_page_block_children(find_page_id,"+++++++++++++++++++++")
            notionFun.update_page_property_title_name(find_page_id,"VP_Name",p_vp_name)
            notionFun.update_page_property_richText(find_page_id,"Comments",p_comments)
            notionFun.update_page_property_richText(find_page_id,"Path",p_path)
            notionFun.update_page_property_richText(find_page_id,"e_date",date)
    else:
        blockid=notionFun.get_find_blockid_if_match_paragraph_rich_text_in_page_block_children(find_page_id,"+++++++++++++++++++++")
        notionFun.update_page_property_title_name(find_page_id,"VP_Name",p_vp_name)
        notionFun.update_page_property_richText(find_page_id,"Comments",p_comments)
        notionFun.update_page_property_richText(find_page_id,"Path",p_path)

















